using System;
using System.Globalization;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Extensions
{
    /// <summary>
    /// The ActiveObjectExtensions class.
    /// </summary>
    public static class ActiveObjectExtensions
    {
        /// <summary>
        /// Adds the is active.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="endColumn">The end column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsActiveDate(this SelectQueryBuilder queryBuilder, string startColumn, string endColumn, DateTime date)
        {
            var clause = queryBuilder.AddWhere(startColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, startColumn, Comparison.LessOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            clause = queryBuilder.AddWhere(endColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, endColumn, Comparison.GreaterOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is active between dates.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="startDateReferenceValue">The start date reference value.</param>
        /// <param name="endColumn">The end column.</param>
        /// <param name="endDateReferenceValue">The end date reference value.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsActiveBetweenDates(this SelectQueryBuilder queryBuilder, string startColumn,
            DateTime startDateReferenceValue, string endColumn, DateTime endDateReferenceValue)
        {
            var clause = queryBuilder.AddWhere(LogicOperator.And, endColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, endColumn, Comparison.GreaterOrEquals, startDateReferenceValue.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            clause = queryBuilder.AddWhere(LogicOperator.And, startColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, startColumn, Comparison.LessOrEquals, endDateReferenceValue.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is active between dates.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="startDateReferenceValue">The start date reference value.</param>
        /// <param name="endColumn">The end column.</param>
        /// <param name="endDateReferenceValue">The end date reference value.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsStrictActiveBetweenDates(this SelectQueryBuilder queryBuilder, string startColumn,
            DateTime startDateReferenceValue, string endColumn, DateTime endDateReferenceValue)
        {
            var clause = queryBuilder.AddWhere(LogicOperator.And, endColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, endColumn, Comparison.GreaterThan, startDateReferenceValue.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            clause = queryBuilder.AddWhere(LogicOperator.And, startColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, startColumn, Comparison.LessThan, endDateReferenceValue.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is active date.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="referenceColumn">The reference column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsActiveDate(this SelectQueryBuilder queryBuilder, string referenceColumn, DateTime date)
        {
            var clause = queryBuilder.AddWhere(LogicOperator.And, referenceColumn, Comparison.GreaterOrEquals,
                date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));
            clause.AddClause(LogicOperator.And, referenceColumn, Comparison.LessThan,
                date.AddDays(1).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is active date.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="startColumn">The start column.</param>
        /// <param name="endColumn">The end column.</param>
        /// <param name="referenceColumn">The reference column.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsActiveDate(this SelectQueryBuilder queryBuilder,
            string startColumn,
            string endColumn,
            string referenceColumn)
        {
            var clause = queryBuilder.AddWhere(startColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, startColumn, Comparison.LessOrEquals, new SqlLiteral(referenceColumn));

            clause = queryBuilder.AddWhere(endColumn, Comparison.Equals, null);
            clause.AddClause(LogicOperator.Or, endColumn, Comparison.GreaterOrEquals, new SqlLiteral(referenceColumn));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is after date.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="column">The column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsAfterDateOrEqual(this SelectQueryBuilder queryBuilder, string column, DateTime date)
        {
            queryBuilder.AddWhere(column, Comparison.GreaterOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is before date.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="column">The column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsBeforeDateOrEqual(this SelectQueryBuilder queryBuilder, string column, DateTime date)
        {
            ////in order to compare the dates without time.
            var searchDate = date.AddDays(1);

            queryBuilder.AddWhere(column, Comparison.LessThan, searchDate.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }

        /// <summary>
        /// Adds the is after date or equal.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="column">The column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The clause.</returns>
        public static WhereClause AddIsAfterDateOrEqual(this WhereClause whereClause, LogicOperator logicOperator, string column, DateTime date)
        {
            whereClause.AddClause(logicOperator, column, Comparison.GreaterOrEquals, date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return whereClause;
        }

        /// <summary>
        /// Adds the is before date or equal.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="column">The column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The clause.</returns>
        public static WhereClause AddIsBeforeDateOrEqual(this WhereClause whereClause, LogicOperator logicOperator, string column, DateTime date)
        {
            ////in order to compare the dates without time.
            var searchDate = date.AddDays(1);

            whereClause.AddClause(logicOperator, column, Comparison.LessThan, searchDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return whereClause;
        }

        /// <summary>
        /// Adds the is before date.
        /// </summary>
        /// <param name="queryBuilder">The query builder.</param>
        /// <param name="column">The column.</param>
        /// <param name="date">The date.</param>
        /// <returns>The query builder result.</returns>
        public static SelectQueryBuilder AddIsBeforeDate(this SelectQueryBuilder queryBuilder, string column, DateTime date)
        {
            queryBuilder.AddWhere(column, Comparison.LessThan, date.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

            return queryBuilder;
        }
    }
}