
using System;
using System.Data;
using System.Collections.Generic;
using ToDoList.DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDoList.Data
{
   
    public partial class DatHes : DatBase
    {

      
        public DatHes() {


        }
        public DatHes(Guid parTransactionGuid) : base(parTransactionGuid) { }


        public DataTable getFalse()
        {
            string sql = @"select id,yapilacakGorev from ToDoList WHERE durum=0";
            DataTable sonuc = gloDbConnector.ExecuteDataTable(sql, null, false, CommandType.Text);
            return sonuc;
        }

        public DataTable getTrue()
        {
            string sql = @"select id,yapilacakGorev from ToDoList WHERE durum=1";
            DataTable sonuc = gloDbConnector.ExecuteDataTable(sql, null, false, CommandType.Text);
            return sonuc;
        }

        public void updateRow(int id)
        {
            string sql = @"UPDATE ToDoList
                        SET durum = 1
                        WHERE id = @id";
            DbParamCollection insDbParamCollection = new DbParamCollection();
            insDbParamCollection.Add("@id", id);
            gloDbConnector.ExecuteNonQuery(sql, insDbParamCollection,CommandType.Text);
        }

        public void updateNotRow(int id)
        {
            string sql = @"UPDATE ToDoList
                        SET durum = 0
                        WHERE id = @id";
            DbParamCollection insDbParamCollection = new DbParamCollection();
            insDbParamCollection.Add("@id", id);
            gloDbConnector.ExecuteNonQuery(sql, insDbParamCollection, CommandType.Text);
        }

        public void postRow(string text)
        {
            string sql = @"INSERT INTO ToDoList
                        (yapilacakGorev,durum)
                        VALUES
                        (@text,0)";
            DbParamCollection insDbParamCollection = new DbParamCollection();
            insDbParamCollection.Add("@text", text);
            gloDbConnector.ExecuteNonQuery(sql, insDbParamCollection, CommandType.Text);
        }




    }
}