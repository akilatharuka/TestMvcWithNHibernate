using Domain.DAL.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Domain.DAL.Implementations
{
    public class GetListQuery<T> : IGetListQuery<T> where T : class
    {
        /// <summary>
        /// The <see cref="UnitOfWork"/> instance.
        /// </summary>
        private UnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetListQuery{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> associated with this repository.</param>
        public GetListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        /// <inheritdoc/>
        public IEnumerable<T> Execute()
        {
            return this.unitOfWork.Session.QueryOver<T>()
            .List();
        }

        /// <inheritdoc/>
        public IEnumerable<T> Execute(Expression<Func<T, bool>> expression)
        {
            return this.unitOfWork.Session.QueryOver<T>()
              .Where(expression)
              .List();
        }

        /// <inheritdoc/>
        public IEnumerable<T> Execute(Expression<Func<T, object>> orderBy, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Ascending)
            {
                return this.unitOfWork.Session.QueryOver<T>()
                .OrderBy(orderBy).Asc
                .List();
            }
            else
            {
                return this.unitOfWork.Session.QueryOver<T>()
                .OrderBy(orderBy).Desc
                .List();
            }
        }
    }
}
