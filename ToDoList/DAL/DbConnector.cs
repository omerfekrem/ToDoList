using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Collections;

namespace ToDoList.DAL
{
    public class DbConnector
    {
        public DbConnector()
        {
            _ConnectionString = "server =.;database=ToDoList;integrated security=true";

        }
        public DbConnector(string parConnectionString)
        {
            _ConnectionString = parConnectionString;
        }
        private DbProviderFactory insDbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        private string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        private DbConnection _Connection = null;
        private DbTransaction _Transaction = null;

        public void OpenConnection()
        {
            if (_Connection == null)
            {
                _Connection = insDbProviderFactory.CreateConnection();
                _Connection.ConnectionString = _ConnectionString;
            }
            if (_Connection.State == ConnectionState.Closed)
            {
                try
                {
                  
                    _Connection.Open();
                }
                catch (Exception ex)
                {

                    //throw new DbConnectorException("Veri Tabani Baglantisi Acilirken Hata. Hata Mesaji : " + ex.Message, ex);
                }

            }
        }
        public void CloseConnecion()
        {
            if (_Transaction == null)
            {
                if (_Connection != null)
                {
                    try
                    {
                        _Connection.Close();
                    }
                    catch (Exception ex)
                    {

                        //throw new DbConnectorException("Veri Tabani Baglantisi Kapatilirken Hata. Hata Mesaji : " + ex.Message, ex);
                    }

                    _Connection.Dispose();
                    _Connection = null;
                }
            }
        }

        public void BeginTransaction()
        {
            if (_Connection == null || _Connection.State == ConnectionState.Closed)
            {
                this.OpenConnection();
            }
            if (_Transaction == null)
            {
                try
                {
                    _Transaction = _Connection.BeginTransaction();
                }
                catch (Exception ex)
                {

                    //throw new DbConnectorException("Transaction Baslatilirken Hata. Hata Mesaji : " + ex.Message, ex);
                }

            }

        }
        public void CommitTransaction()
        {
            if (_Transaction != null)
            {
                try
                {
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {

                    //throw new DbConnectorException("Transaction Commit Edilirken Hata. Hata Mesaji : " + ex.Message, ex);
                }

                _Transaction.Dispose();
                _Transaction = null;
                this.CloseConnecion();
            }
        }
        public void RollbackTransaction()
        {
            if (_Transaction != null)
            {
                try
                {
                    _Transaction.Rollback();
                }
                catch (Exception ex)
                {

                    //throw new DbConnectorException("Transaction Rollback Edilirken Hata. Hata Mesaji : " + ex.Message, ex);
                }

                _Transaction.Dispose();
                _Transaction = null;
                this.CloseConnecion();
            }
        }

        public DbCommand CreateCommand(string parCommandText, DbParamCollection parDbParameters)
        {
            DbCommand insDbCommand = insDbProviderFactory.CreateCommand();
            insDbCommand.CommandText = parCommandText;
            insDbCommand.CommandType = CommandType.StoredProcedure;
            insDbCommand.CommandTimeout = 6000;
            if (parDbParameters != null)
            {
                insDbCommand.Parameters.AddRange(parDbParameters.ToArray());
            }
            insDbCommand.Connection = _Connection;
            if (_Transaction != null)
            {
                insDbCommand.Transaction = _Transaction;
            }
            return insDbCommand;
        }
        public DbCommand CreateCommand(string parCommandText, DbParamCollection parDbParameters, CommandType cmdType)
        {
            DbCommand insDbCommand = insDbProviderFactory.CreateCommand();
            insDbCommand.CommandText = parCommandText;
            insDbCommand.CommandType = cmdType;
            if (parDbParameters != null)
            {
                insDbCommand.Parameters.AddRange(parDbParameters.ToArray());
            }
            insDbCommand.Connection = _Connection;
            if (_Transaction != null)
            {
                insDbCommand.Transaction = _Transaction;
            }
            return insDbCommand;
        }
        public DataTable ExecuteDataTable(string parCommandText, DbParamCollection parDbParameters)
        {
            return ExecuteDataTable(parCommandText, parDbParameters, false);
        }
        public DataTable ExecuteDataTable(string parCommandText, DbParamCollection parDbParameters, bool parIsCached)
        {
            DataTable insDataTable = new DataTable();
            if (parIsCached)
            {
                if (AppDomain.CurrentDomain.GetData(parCommandText) == null)
                {
                    this.OpenConnection();
                    DbDataAdapter insDbDataAdapter = insDbProviderFactory.CreateDataAdapter();
                    insDbDataAdapter.SelectCommand = CreateCommand(parCommandText, parDbParameters);

                    try
                    {
                        insDbDataAdapter.Fill(insDataTable);
                    }
                    catch (Exception ex)
                    {
                        //throw new DbConnectorException("ExecuteDataTable Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
                    }

                    this.CloseConnecion();
                    AppDomain.CurrentDomain.SetData(parCommandText, insDataTable);
                }
                else
                {
                    insDataTable = (DataTable)(AppDomain.CurrentDomain.GetData(parCommandText));
                }
            }
            else
            {
                this.OpenConnection();
                DbDataAdapter insDbDataAdapter = insDbProviderFactory.CreateDataAdapter();
                insDbDataAdapter.SelectCommand = CreateCommand(parCommandText, parDbParameters);
                try
                {
                    insDbDataAdapter.Fill(insDataTable);
                }
                catch (Exception ex)
                {
                    //throw new DbConnectorException("ExecuteDataTable Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
                }

                this.CloseConnecion();
            }

            return insDataTable;
        }
        public DataTable ExecuteDataTable(string parCommandText, DbParamCollection parDbParameters, bool parIsCached, CommandType cmdType)
        {
            DataTable insDataTable = new DataTable();
            if (parIsCached)
            {
                if (AppDomain.CurrentDomain.GetData(parCommandText) == null)
                {
                    this.OpenConnection();
                    DbDataAdapter insDbDataAdapter = insDbProviderFactory.CreateDataAdapter();
                    insDbDataAdapter.SelectCommand = CreateCommand(parCommandText, parDbParameters);

                    try
                    {
                        insDbDataAdapter.Fill(insDataTable);
                    }
                    catch (Exception ex)
                    {
                        //throw new DbConnectorException("ExecuteDataTable Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
                    }

                    this.CloseConnecion();
                    AppDomain.CurrentDomain.SetData(parCommandText, insDataTable);
                }
                else
                {
                    insDataTable = (DataTable)(AppDomain.CurrentDomain.GetData(parCommandText));
                }
            }
            else
            {
                this.OpenConnection();
                DbDataAdapter insDbDataAdapter = insDbProviderFactory.CreateDataAdapter();
                insDbDataAdapter.SelectCommand = CreateCommand(parCommandText, parDbParameters, cmdType);
                try
                {
                    insDbDataAdapter.Fill(insDataTable);
                }
                catch (Exception ex)
                {
                    //throw new DbConnectorException("ExecuteDataTable Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
                }

                this.CloseConnecion();
            }

            return insDataTable;
        }
        public int ExecuteNonQuery(string parCommandText, DbParamCollection parDbParameters)
        {
            this.OpenConnection();
            int countOfRowsAffected;
            countOfRowsAffected = 0;
            try
            {
                countOfRowsAffected = CreateCommand(parCommandText, parDbParameters).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new DbConnectorException("ExecuteNonQuery Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
            }

            this.CloseConnecion();
            return countOfRowsAffected;
        }
        public int ExecuteNonQuery(string parCommandText, DbParamCollection parDbParameters, CommandType cmdType)
        {
            this.OpenConnection();
            int countOfRowsAffected;
            countOfRowsAffected = 0;
            try
            {
                countOfRowsAffected = CreateCommand(parCommandText, parDbParameters, cmdType).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //throw new DbConnectorException("ExecuteNonQuery Komutu Calisirken Hata. Hata Ureten Komut :" + parCommandText + "  Hata Mesaji :" + ex.Message, ex);
            }

            this.CloseConnecion();
            return countOfRowsAffected;
        }
        public object ExecuteScalar(string parCommandText, DbParamCollection parDbParameters)
        {
            this.OpenConnection();
            object value;
            value = 0;
            try
            {
                value = CreateCommand(parCommandText, parDbParameters).ExecuteScalar();
            }
            catch (Exception ex)
            {
                //throw new DbConnectorException("ExecuteScalar Komutu Calisirken Hata.Hata Ureten Komut :" + parCommandText + " Hata Mesaji :" + ex.Message, ex);
            }

            this.CloseConnecion();
            return value;
        }
        public DbDataReader GetDbDataReader(string parCommandText, DbParamCollection parDbParameters, CommandBehavior behavior)
        {
            this.OpenConnection();
            try
            {
                return CreateCommand(parCommandText, parDbParameters).ExecuteReader(behavior);
            }
            catch (Exception ex)
            {
                //throw new DbConnectorException("DBDataReader Komutu Calisirken Hata.Hata Ureten Komut :" + parCommandText + " Hata Mesaji :" + ex.Message, ex);
            }
            return null;
        }
    }
    public class DbParamCollection : CollectionBase, ICollection<DbParameter>
    {
        DbProviderFactory insDbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        #region ICollection<DbParameter> Members
        private int _OutputParameterIndex;
        public void Add(DbParameter item)
        {
            InnerList.Add(item);
        }
        public void Add(string parameterName, object parameterValue)
        {
            DbParameter insDbparameter = insDbProviderFactory.CreateParameter();
            insDbparameter.ParameterName = parameterName;
            if (parameterValue == null)
            {
                parameterValue = DBNull.Value;
            }
            insDbparameter.Value = parameterValue;
            InnerList.Add(insDbparameter);
        }

        public void AddOutput(string parameterName, DbType parDbType)
        {
            DbParameter insDbparameter = insDbProviderFactory.CreateParameter();
            insDbparameter.ParameterName = parameterName;
            insDbparameter.DbType = parDbType;
            insDbparameter.Direction = ParameterDirection.Output;
            _OutputParameterIndex = InnerList.Add(insDbparameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parDbType"></param>
        /// <param name="Size">string tipindeki değişkenin uzunluğu</param>
        public void AddOutput(string parameterName, DbType parDbType, int Size)
        {
            DbParameter insDbparameter = insDbProviderFactory.CreateParameter();
            insDbparameter.ParameterName = parameterName;
            insDbparameter.DbType = parDbType;
            insDbparameter.Size = Size;
            insDbparameter.Direction = ParameterDirection.Output;
            _OutputParameterIndex = InnerList.Add(insDbparameter);
        }
        public DbParameter GetOutPutParameter()
        {
            return (DbParameter)InnerList[_OutputParameterIndex];
        }

        public bool Contains(DbParameter item)
        {
            return InnerList.Contains(item);
        }

        public void CopyTo(DbParameter[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get
            {
                return InnerList.IsReadOnly;
            }
        }

        public bool Remove(DbParameter item)
        {
            InnerList.Remove(item);
            return true;
        }
        public Array ToArray()
        {
            return InnerList.ToArray();
        }

        #endregion

        #region IEnumerable<DbParameter> Members

        public new IEnumerator<DbParameter> GetEnumerator()
        {
            return (IEnumerator<DbParameter>)InnerList.GetEnumerator();
        }

        #endregion

    }
}
