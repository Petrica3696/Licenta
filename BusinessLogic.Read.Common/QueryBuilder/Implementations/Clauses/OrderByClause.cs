using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses
{
    /// <summary>
    /// The OrderByClause struct.
    /// </summary>
    public struct OrderByClause
    {
        /// <summary>
        /// The field name.
        /// </summary>
        public string FieldName;

        /// <summary>
        /// The sort order.
        /// </summary>
        public Sorting SortOrder;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderByClause" /> struct.
        /// </summary>
        /// <param name="field">The field.</param>
        public OrderByClause(string field)
        {
            FieldName = field;
            SortOrder = Sorting.Ascending;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderByClause" /> struct.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="order">The order.</param>
        public OrderByClause(string field, Sorting order)
        {
            FieldName = field;
            SortOrder = order;
        }
    }
}