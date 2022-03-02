using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_9FW.DataAccess
{
    internal interface IDataAccess<TEntity > where TEntity : class
    {
        void Insert();
        void Delete();
        void Update();
        void Read();

    }
}
