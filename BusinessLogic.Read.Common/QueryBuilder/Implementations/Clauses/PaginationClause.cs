namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses
{
    /// <summary>
    /// The PaginationClause class.
    /// </summary>
    public class PaginationClause
    {
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int? Max { get; set; }
    }
}