using System.Linq.Expressions;
using Blater.Query.Interfaces;

namespace Blater.Query.Models
{
    /// <summary>
    /// a view of the query that we are processing
    /// </summary>
    public class LinqQuery
    {
        private readonly List<Expression?> _whereClauses = [];
        private readonly List<OrderBy> _ordering = []; 

        public LinqQuery(Expression fullQuery)
        {
            Paging = new Paging();
            FullQuery = fullQuery;
            PostProcess = new DefaultPostProcess();
        }

        /// <summary>
        /// the where clauses to be processed by couchdb, which needs to be converted into mongo json and executed
        /// </summary>
        public IEnumerable<Expression?> WhereClauses => _whereClauses;
        
        /// <summary>
        /// the parent query, anything we cannot do with couchdb will need to be
        /// executed in .NET with the result set.
        /// </summary>
        public BlaterQuery? ParentQuery { get; set; }

        /// <summary>
        /// the origonal query
        /// </summary>
        public Expression FullQuery { get; set; }

        /// <summary>
        /// simple paging rules
        /// </summary>
        public Paging Paging { get; set; }

        
        /// <summary>
        /// the property name to order the results by
        /// </summary>
        public IEnumerable<OrderBy> Ordering { get { return _ordering; } }

        public Func<object, object>? PostIndexProcessing { get; set; }

        public IPostProcess PostProcess { get; set; }


        public void AddWhereClause(Expression? expression)
        {
            _whereClauses.Add(expression);
        }

        public void AddOrderBy(OrderBy order)
        {
            _ordering.Add(order);
        }
     
        //need to see how we support facets
        //public MethodCallExpression GroupBy { get; set; }

    }
}