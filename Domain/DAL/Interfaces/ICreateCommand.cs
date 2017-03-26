using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Interfaces
{
    public interface ICreateCommand<T> where T : class
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        /// <returns>Query result.</returns>
        object Execute(T entity);
    }
}
