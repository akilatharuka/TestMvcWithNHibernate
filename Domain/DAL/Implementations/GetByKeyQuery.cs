using Domain.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL.Implementations
{
    public class GetByKeyQuery<T> : IGetByKeyQuery<T> where T : class
    {
        /// <summary>
        /// The <see cref="UnitOfWork"/> instance.
        /// </summary>
        private UnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetByKeyQuery{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> associated with this repository.</param>
        public GetByKeyQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        /// <inheritdoc/>
        public T Execute(object key)
        {
            return this.unitOfWork.Session.Get<T>(key);
        }
    }
}
