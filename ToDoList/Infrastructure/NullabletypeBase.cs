using System;

namespace DatagridToExcel.Infrastructure
{

   public abstract class NullabletypeBase
   {
       protected bool _HasValue;
       public bool HasValue
       {
           get { return this._HasValue; }
       }

       protected object _ObjectValue;
       public object ValueBoxed
       {
           get
           {
               if (this._HasValue) return this._ObjectValue;
               return null;
           }
       }

   }
}
