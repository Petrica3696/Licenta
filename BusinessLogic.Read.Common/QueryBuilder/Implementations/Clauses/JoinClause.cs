using System;
using System.Globalization;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses
{
    /// <summary>
    /// The JoinClause class.
    /// </summary>
    public class JoinClause : WhereClause
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JoinClause" /> class.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toColumnName">Name of to column.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="fromTableName">Name of from table.</param>
        /// <param name="fromColumnName">Name of from column.</param>
        public JoinClause(JoinType join, string toTableName, string toColumnName, Comparison @operator,
            string fromTableName, string fromColumnName)
            : this(join, toTableName, string.Empty, toColumnName, @operator, fromTableName, fromColumnName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinClause" /> class.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toTableAlias">To table alias.</param>
        /// <param name="toColumnName">Name of to column.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="fromTableName">Name of from table.</param>
        /// <param name="fromColumnName">Name of from column.</param>
        public JoinClause(JoinType join, string toTableName, string toTableAlias, string toColumnName,
            Comparison @operator, string fromTableName,
            string fromColumnName)
            : base(
                null, fromTableName + '.' + fromColumnName, @operator,
                new SqlLiteral((!string.IsNullOrEmpty(toTableAlias) ? toTableAlias : toTableName) + '.' + toColumnName))
        {
            JoinType = join;
            ToTable = toTableName;
            ToColumn = toColumnName;
            ToTableAlias = toTableAlias;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinClause" /> class.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toTableAlias">To table alias.</param>
        public JoinClause(JoinType join, string toTableName, string toTableAlias)
            : base(null, "1", Comparison.Equals, 1)
        {
            JoinType = join;
            ToTable = toTableName;
            ToColumn = "1";
            ToTableAlias = toTableAlias;
        }

        /// <summary>
        /// Gets or sets the type of the join.
        /// </summary>
        /// <value>The type of the join.</value>
        public JoinType JoinType { get; set; }

        /// <summary>
        /// Gets or sets to table.
        /// </summary>
        /// <value>To table.</value>
        public string ToTable { get; set; }

        /// <summary>
        /// Gets or sets to table alias.
        /// </summary>
        /// <value>To table alias.</value>
        public string ToTableAlias { get; set; }

        /// <summary>
        /// Gets or sets to column.
        /// </summary>
        /// <value>To column.</value>
        public string ToColumn { get; set; }

        /// <summary>
        /// Adds the clause.
        /// </summary>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="field1">The field1.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <param name="field2">The field2.</param>
        public void AddClauseWithField(LogicOperator logicOperator, string field1, Comparison comparisonOperator, string field2)
        {
            AddClause(logicOperator, field1, comparisonOperator, new SqlLiteral(field2));
        }

        /// <summary>
        /// Adds the clause is active between dates.
        /// </summary>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="endColumn">The end column.</param>
        /// <param name="date">The date.</param>
        public void AddClauseIsActiveBetweenDates(LogicOperator logicOperator, string startColumn, string endColumn, DateTime date)
        {
            var whereClause = new WhereClause(logicOperator, startColumn, Comparison.Equals, null);
            whereClause.AddClause(Enums.LogicOperator.Or, startColumn, Comparison.LessOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
            Clauses.Add(whereClause);

            whereClause = new WhereClause(logicOperator, endColumn, Comparison.Equals, null);
            whereClause.AddClause(Enums.LogicOperator.Or, endColumn, Comparison.GreaterOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
            Clauses.Add(whereClause);
        }
    }
}