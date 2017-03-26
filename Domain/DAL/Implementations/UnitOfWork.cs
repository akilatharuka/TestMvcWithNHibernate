using Domain.DAL.Interfaces;
using System;

using System.Data;

using Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Domain.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// <see cref="ISessionFactory"/> instance.
        /// </summary>
        private static ISessionFactory sessionFactory = BuildSessionFactory();

        /// <summary>
        /// Value indicating whether the unit of work is disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// <see cref="ITransaction"/> instance.
        /// </summary>
        private ITransaction transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            this.Session = sessionFactory.OpenSession();
            this.transaction = this.Session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// The database connection.
        /// </summary>
        /// <value>
        /// IDBConnection.
        /// </value>
        public IDbConnection DBConnection
        {
            get
            {
                return this.Session.Connection;
            }
        }

        /// <summary>
        /// Gets the underlying NHibernate session.
        /// </summary>
        /// <value>
        /// The underlying NHibernate session.
        /// </value>
        public ISession Session { get; private set; }

        /// <inheritdoc/>
        public void Commit()
        {
            if (!this.transaction.IsActive)
            {
                throw new InvalidOperationException("Transaction is not active");
            }

            this.transaction.Commit();
        }

        /// <inheritdoc/>
        public void Rollback()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Clean up resources.
        /// </summary>
        /// <param name="disposing">A boolean indicating if this method is called from the <see cref="Dispose()"/> method.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Session.Close();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Builds a session factory.
        /// </summary>
        /// <returns>The created session factory.</returns>
        private static ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey("ItwConnection")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UnitOfWork>())
                .ExposeConfiguration(UpdateSchema)
                .BuildSessionFactory();
        }

        /// <summary>
        /// Updates the schema.
        /// </summary>
        /// <param name="configuration">Configuration object.</param>
        private static void UpdateSchema(Configuration configuration)
        {
            new SchemaUpdate(configuration).Execute(true, true);
        }
    }
}
