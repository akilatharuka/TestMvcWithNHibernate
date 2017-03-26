using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Interfaces
{
    public interface IUpdateCommand<T> where T : class
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="id">Id to update.</param>
        /// <param name="entity">New entity data.</param>
        void Execute(int id, T entity);
    }
}
