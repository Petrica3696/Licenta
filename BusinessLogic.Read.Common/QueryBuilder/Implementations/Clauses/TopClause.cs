using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses
{
    /// <summary>
    /// The TopClause struct.
    /// </summary>
    public struct TopClause
    {
        /// <summary>
        /// The quantity.
        /// </summary>
        public int Quantity;

        /// <summary>
        /// The unit.
        /// </summary>
        public TopUnit Unit;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopClause" /> struct.
        /// </summary>
        /// <param name="nr">The nr.</param>
        public TopClause(int nr)
        {
            Quantity = nr;
            Unit = TopUnit.Records;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopClause" /> struct.
        /// </summary>
        /// <param name="nr">The nr.</param>
        /// <param name="topUnit">The top unit.</param>
        public TopClause(int nr, TopUnit topUnit)
        {
            Quantity = nr;
            Unit = topUnit;
        }
    }
}