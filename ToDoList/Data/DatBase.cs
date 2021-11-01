using System;
using System.Collections;

using ToDoList.DAL;

namespace ToDoList.Data
{
    public class DatBase
    {
        public DbConnector gloDbConnector;
        public static Hashtable conns = new Hashtable();
        private Guid _tCode;

        public DatBase()
        {
            gloDbConnector = new DbConnector();
        }

        public DatBase(Guid tCode)
        {
            if (tCode != Guid.Empty)
            {
                _tCode = tCode;
                if (conns.ContainsKey(tCode))
                {
                    this.gloDbConnector = (DbConnector) conns[tCode];
                }
                else
                {
                    gloDbConnector = new DbConnector();
                    gloDbConnector.BeginTransaction();
                    conns.Add(tCode, this.gloDbConnector);
                }
            }
            else
            {
                gloDbConnector = new DbConnector();
            }
        }

        public void Commit()
        {
            gloDbConnector.CommitTransaction();
            conns.Remove(_tCode);
        }

        public void Rollback()
        {
            gloDbConnector.RollbackTransaction();
            conns.Remove(_tCode);
        }

    }
}
