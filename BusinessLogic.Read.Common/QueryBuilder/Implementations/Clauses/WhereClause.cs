using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses
{
    /// <summary>
    /// The WhereClause class.
    /// </summary>
    public class WhereClause
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhereClause"/> class.
        /// Initializes a new instance of the <see cref="WhereClause"/> struct.
        /// </summary>
        /// <param name="logicOperator">
        /// The logic operator.
        /// </param>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="firstCompareOperator">
        /// The first compare operator.
        /// </param>
        /// <param name="firstCompareValue">
        /// The first compare value.
        /// </param>
        public WhereClause(LogicOperator? logicOperator, string field, Comparison firstCompareOperator, object firstCompareValue)
        {
            FieldName = field;
            ComparisonOperator = firstCompareOperator;
            Value = firstCompareValue;
            LogicOperator = logicOperator;
            Clauses = new List<WhereClause>();
        }

        /// <summary>
        /// Gets or sets the logic operator.
        /// </summary>
        /// <value>The logic operator.</value>
        public LogicOperator? LogicOperator { get; set; }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the comparison operator.
        /// </summary>
        /// <value>The comparison operator.</value>
        public Comparison ComparisonOperator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the clauses.
        /// </summary>
        /// <value>The clauses.</value>
        public List<WhereClause> Clauses { get; set; }

        /// <summary>
        /// Creates the comparison clause.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <param name="value">The value.</param>
        /// <returns>The comparison clause.</returns>
        /// <exception cref="System.Exception">
        /// Cannot use comparison operator " + comparisonOperator + " for NULL values.
        /// </exception>
        public static string CreateComparisonClause(string fieldName, Comparison comparisonOperator, object value)
        {
            var output = string.Empty;
            if (value != null && value != DBNull.Value)
            {
                switch (comparisonOperator)
                {
                    case Comparison.Equals:
                        output = fieldName + " = " + FormatSqlValue(value);
                        break;

                    case Comparison.NotEquals:
                        output = fieldName + " <> " + FormatSqlValue(value);
                        break;

                    case Comparison.GreaterThan:
                        output = fieldName + " > " + FormatSqlValue(value);
                        break;

                    case Comparison.GreaterOrEquals:
                        output = fieldName + " >= " + FormatSqlValue(value);
                        break;

                    case Comparison.LessThan:
                        output = fieldName + " < " + FormatSqlValue(value);
                        break;

                    case Comparison.LessOrEquals:
                        output = fieldName + " <= " + FormatSqlValue(value);
                        break;

                    case Comparison.Like:
                        output = fieldName + " LIKE " + FormatSqlValue(value);
                        break;

                    case Comparison.NotLike:
                        output = "NOT " + fieldName + " LIKE " + FormatSqlValue(value);
                        break;

                    case Comparison.In:
                        output = fieldName + " IN (" + FormatSqlValue(value) + ")";
                        break;

                    case Comparison.NotIn:
                        output = fieldName + " NOT IN (" + FormatSqlValue(value) + ")";
                        break;

                    case Comparison.InLike:
                        output = BuildInLikeStatement(fieldName, value);
                        break;
                }
            }
            else
            {
                if (comparisonOperator != Comparison.Equals && comparisonOperator != Comparison.NotEquals)
                {
                    throw new Exception("Cannot use comparison operator " + comparisonOperator + " for NULL values.");
                }

                switch (comparisonOperator)
                {
                    case Comparison.Equals:
                        output = fieldName + " IS NULL";
                        break;

                    case Comparison.NotEquals:
                        output = "NOT " + fieldName + " IS NULL";
                        break;
                }
            }

            return output;
        }

        /// <summary>
        /// Formats the SQL value.
        /// </summary>
        /// <param name="someValue">Some value.</param>
        /// <returns>The formatted sql.</returns>
        public static string FormatSqlValue(object someValue)
        {
            string formatSqlValue;

            if (someValue == null)
            {
                formatSqlValue = "NULL";
            }
            else
            {
                switch (someValue.GetType().Name)
                {
                    case "String":
                        formatSqlValue = "'" + ((string)someValue).Replace("'", "''") + "'";
                        break;

                    case "DateTime":
                        formatSqlValue = "'" + ((DateTime)someValue).ToString("yyyy/MM/dd hh:mm:ss", CultureInfo.InvariantCulture) + "'";
                        break;

                    case "DBNull":
                        formatSqlValue = "NULL";
                        break;

                    case "Boolean":
                        formatSqlValue = (bool)someValue ? "1" : "0";
                        break;

                    case "SqlLiteral":
                        formatSqlValue = ((SqlLiteral)someValue).Value;
                        break;

                    case "List`1":
                        if (someValue is List<string>)
                        {
                            var valueList = someValue as List<string>;
                            if (valueList.Any())
                            {
                                formatSqlValue = valueList.Aggregate(new StringBuilder(), (current, value) => current.Append(",\'" + value + "\'"), (current) => current.Remove(0, 1).ToString());
                            }
                            else
                            {
                                formatSqlValue = string.Empty;
                            }
                        }
                        else if (someValue is List<Guid>)
                        {
                            var valueList = someValue as List<Guid>;
                            if (valueList.Any())
                            {
                                formatSqlValue = valueList.Aggregate(new StringBuilder(), (current, value) => current.Append(",\'" + value + "\'"), current => current.Remove(0, 1).ToString());
                            }
                            else
                            {
                                formatSqlValue = string.Empty;
                            }
                        }
                        else if (someValue is List<int>)
                        {
                            var valueList = someValue as List<int>;
                            if (valueList.Any())
                            {
                                formatSqlValue = valueList.Aggregate(new StringBuilder(), (current, value) => current.Append("," + value), current => current.Remove(0, 1).ToString());
                            }
                            else
                            {
                                formatSqlValue = string.Empty;
                            }
                        }
                        else if (someValue is List<long>)
                        {
                            var valueList = someValue as List<long>;
                            if (valueList.Any())
                            {
                                formatSqlValue = valueList.Aggregate(new StringBuilder(), (current, value) => current.Append("," + value), current => current.Remove(0, 1).ToString());
                            }
                            else
                            {
                                formatSqlValue = string.Empty;
                            }
                        }
                        else
                        {
                            formatSqlValue = string.Empty;
                        }

                        break;

                    default:
                        formatSqlValue = someValue.ToString();
                        break;
                }
            }

            return formatSqlValue;
        }

        /// <summary>
        /// Adds the clause.
        /// </summary>
        /// <param name="logic">The logic.</param>
        /// <param name="field">The field.</param>
        /// <param name="compareOperator">The compare operator.</param>
        /// <param name="compareValue">The compare value.</param>
        /// <returns>The WhereClause.</returns>
        public WhereClause AddClause(LogicOperator logic, string field, Comparison compareOperator, object compareValue)
        {
            var where = new WhereClause(logic, field, compareOperator, compareValue);
            Clauses.Add(where);
            return where;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (LogicOperator.HasValue)
            {
                switch (LogicOperator.Value)
                {
                    case Enums.LogicOperator.And:
                        sb.Append(" AND ");
                        break;

                    case Enums.LogicOperator.Or:
                        sb.Append(" OR ");
                        break;
                }
            }

            if (Clauses.Any())
            {
                sb.Append('(');
            }

            sb.Append(CreateComparisonClause(FieldName, ComparisonOperator, Value));

            foreach (var clause in Clauses)
            {
                sb.Append(clause);
            }

            if (Clauses.Any())
            {
                sb.Append(')');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Builds the in like statement.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns>The statement.</returns>
        private static string BuildInLikeStatement(string fieldName, object value)
        {
            if (!(value is List<string>))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var fields = fieldName.Split(',');
            var parts = (List<string>)value;

            sb.Append("(");

            foreach (var part in parts)
            {
                sb.Append("(");

                foreach (var field in fields)
                {
                    sb.Append($"{field} LIKE '{part}' OR ");
                }

                sb.Remove(sb.Length - 4, 4);
                sb.Append(")");
                sb.Append(" AND ");
            }

            sb.Remove(sb.Length - 5, 5);

            sb.Append(")");

            return sb.ToString();
        }
    }
}