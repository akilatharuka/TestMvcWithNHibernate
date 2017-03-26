using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.DAL.Interfaces
{
    public interface IGetListQuery<T> where T : class
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <returns>Query result.</returns>
        IEnumerable<T> Execute();

        /// <summary>
        /// Execute the query.
        /// </summary>
        /// <param name="expression">Filtering expression</param>
        /// <returns>Query result.</returns>
        IEnumerable<T> Execute(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Execute the query.
        /// </summary>
        /// <param name="orderBy">Order By expression</param>
        /// <param name="sortOrder">The sort order</param>
        /// <returns>Query result.</returns>
        IEnumerable<T> Execute(Expression<Func<T, object>> orderBy, SortOrder sortOrder);
    }
}
