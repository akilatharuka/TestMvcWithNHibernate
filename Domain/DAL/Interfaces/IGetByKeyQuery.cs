using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Interfaces
{
    public interface IGetByKeyQuery<T> where T : class
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="key">Key to fetch.</param>
        /// <returns>Query result.</returns>
        T Execute(object key);
    }
}
