using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The database connection.
        /// </summary>
        /// <value>
        /// IDBConnection.
        /// </value>
        IDbConnection DBConnection { get; }

        /// <summary>
        /// Commits the changes in this unit of work.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback changes in this unit of work.
        /// </summary>
        void Rollback();
    }
}
