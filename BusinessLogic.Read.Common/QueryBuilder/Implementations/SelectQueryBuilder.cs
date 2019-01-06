using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using BusinessLogic.Read.Common.QueryBuilder.Abstractions;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Clauses;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Enums;
using BusinessLogic.Read.Common.QueryBuilder.Implementations.Extensions;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations
{
    /// <summary>
    /// The SelectQueryBuilder class.
    /// </summary>
    /// <seealso cref="IQueryBuilder" />
    public class SelectQueryBuilder : IQueryBuilder
    {
        /// <summary>
        /// The _DB provider factory.
        /// </summary>
        private DbProviderFactory _dbProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectQueryBuilder" /> class.
        /// </summary>
        public SelectQueryBuilder()
        {
            GroupByColumns = new List<string>();
            HavingClauses = new List<WhereClause>();
            JoinClauses = new List<JoinClause>();
            OrderByStatement = new List<OrderByClause>();
            SelectedColumns = new List<string>();
            SelectedTables = new List<string>();
            TopClause = new TopClause(100, TopUnit.Percent);
            WhereClauses = new List<WhereClause>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SelectQueryBuilder" /> is distinct.
        /// </summary>
        /// <value><c>true</c> if distinct; otherwise, <c>false</c>.</value>
        public bool Distinct { get; set; }

        /// <summary>
        /// Gets or sets the top records.
        /// </summary>
        /// <value>The top records.</value>
        public int TopRecords
        {
            get { return TopClause.Quantity; }
            set { TopClause = new TopClause(value, TopUnit.Records); }
        }

        /// <summary>
        /// Gets or sets the where statement.
        /// </summary>
        /// <value>The where statement.</value>
        protected List<WhereClause> WhereClauses { get; set; }

        /// <summary>
        /// Gets or sets the top clause.
        /// </summary>
        /// <value>The top clause.</value>
        protected TopClause TopClause { get; set; }

        /// <summary>
        /// Gets or sets the selected columns.
        /// </summary>
        /// <value>The selected columns.</value>
        protected List<string> SelectedColumns { get; set; }

        /// <summary>
        /// Gets or sets the selected tables.
        /// </summary>
        /// <value>The selected tables.</value>
        protected List<string> SelectedTables { get; set; }

        /// <summary>
        /// Gets or sets the having statement.
        /// </summary>
        /// <value>The having statement.</value>
        protected List<WhereClause> HavingClauses { get; set; }

        /// <summary>
        /// Gets or sets the join clauses.
        /// </summary>
        /// <value>The join clauses.</value>
        protected List<JoinClause> JoinClauses { get; set; }

        /// <summary>
        /// Gets or sets the order by statement.
        /// </summary>
        /// <value>The order by statement.</value>
        protected List<OrderByClause> OrderByStatement { get; set; }

        /// <summary>
        /// Gets or sets the group by columns.
        /// </summary>
        /// <value>The group by columns.</value>
        protected List<string> GroupByColumns { get; set; }

        /// <summary>
        /// Gets or sets the pagination clause.
        /// </summary>
        /// <value>The pagination clause.</value>
        protected PaginationClause PaginationClause { get; set; }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns>The query statement.</returns>
        public string BuildQuery()
        {
            return (string)BuildQuery(false);
        }

        /// <summary>
        /// Sets the database provider factory.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public void SetDbProviderFactory(DbProviderFactory factory)
        {
            _dbProviderFactory = factory;
        }

        /// <summary>
        /// Selects all columns.
        /// </summary>
        public void SelectAllColumns()
        {
            SelectedColumns.Clear();
        }

        /// <summary>
        /// Selects the count.
        /// </summary>
        public void SelectCount()
        {
            SelectColumn("count(1)");
        }

        /// <summary>
        /// Selects the count.
        /// </summary>
        /// <param name="field">The field.</param>
        public void SelectDistinctCount(string field)
        {
            SelectColumn("count(distinct " + field + ")");
        }

        /// <summary>
        /// Selects the column.
        /// </summary>
        /// <param name="column">The column.</param>
        public void SelectColumn(string column)
        {
            SelectedColumns.Clear();
            SelectedColumns.Add(column);
        }

        /// <summary>
        /// Selects the columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void SelectColumns(params string[] columns)
        {
            foreach (var column in columns)
            {
                SelectedColumns.Add(column);
            }
        }

        /// <summary>
        /// Adds the components.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void AddComponents(string[] columns)
        {
            SelectedColumns.AddRange(columns);
        }

        /// <summary>
        /// Selects from table.
        /// </summary>
        /// <param name="table">The table.</param>
        public void SelectFromTable(string table)
        {
            SelectedTables.Clear();
            SelectedTables.Add(table);
        }

        /// <summary>
        /// Selects from tables.
        /// </summary>
        /// <param name="tables">The tables.</param>
        public void SelectFromTables(params string[] tables)
        {
            SelectedTables.Clear();
            foreach (var table in tables)
            {
                SelectedTables.Add(table);
            }
        }

        /// <summary>
        /// Adds the join.
        /// </summary>
        /// <param name="newJoin">The new join.</param>
        public void AddJoin(JoinClause newJoin)
        {
            JoinClauses.Add(newJoin);
        }

        /// <summary>
        /// Adds the join.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toColumnName">Name of to column.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="fromTableName">Name of from table.</param>
        /// <param name="fromColumnName">Name of from column.</param>
        /// <returns>The created join clause.</returns>
        public JoinClause AddJoin(JoinType join, string toTableName, string toColumnName, Comparison @operator, string fromTableName, string fromColumnName)
        {
            var newJoin = new JoinClause(join, toTableName, toColumnName, @operator, fromTableName, fromColumnName);
            JoinClauses.Add(newJoin);

            return newJoin;
        }

        /// <summary>
        /// Adds the join.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toTableAlias">To table alias.</param>
        /// <param name="toColumnName">Name of to column.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="fromTableAlias">From table alias.</param>
        /// <param name="fromColumnName">Name of from column.</param>
        /// <returns>The created join clause.</returns>
        public JoinClause AddJoin(JoinType join, string toTableName, string toTableAlias, string toColumnName, Comparison @operator, string fromTableAlias, string fromColumnName)
        {
            var newJoin = new JoinClause(join, toTableName, toTableAlias, toColumnName, @operator, fromTableAlias, fromColumnName);
            JoinClauses.Add(newJoin);

            return newJoin;
        }

        /// <summary>
        /// Addds the default join.
        /// </summary>
        /// <param name="join">The join.</param>
        /// <param name="toTableName">Name of to table.</param>
        /// <param name="toTableAlias">To table alias.</param>
        /// <returns>The created join clause.</returns>
        public JoinClause AdddDefaultJoin(JoinType join, string toTableName, string toTableAlias)
        {
            var newJoin = new JoinClause(join, toTableName, toTableAlias);
            JoinClauses.Add(newJoin);

            return newJoin;
        }

        /// <summary>
        /// Adds the where.
        /// </summary>
        /// <param name="clause">The clause.</param>
        public void AddWhere(WhereClause clause)
        {
            if (!WhereClauses.Any())
            {
                clause.LogicOperator = null;
            }

            WhereClauses.Add(clause);
        }

        /// <summary>
        /// Adds the where.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="compareValue">The compare value.</param>
        /// <returns>The where clause.</returns>
        public WhereClause AddWhere(string field, Comparison @operator, object compareValue)
        {
            var where = new WhereClause(LogicOperator.And, field, @operator, compareValue);
            AddWhere(where);

            return where;
        }

        /// <summary>
        /// Adds the where.
        /// </summary>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="field">The field.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="compareValue">The compare value.</param>
        /// <returns>The where clause.</returns>
        public WhereClause AddWhere(LogicOperator logicOperator, string field, Comparison @operator, object compareValue)
        {
            var where = new WhereClause(logicOperator, field, @operator, compareValue);
            AddWhere(where);

            return where;
        }

        /// <summary>
        /// Adds the order by.
        /// </summary>
        /// <param name="clause">The clause.</param>
        public void AddOrderBy(OrderByClause clause)
        {
            OrderByStatement.Add(clause);
        }

        /// <summary>
        /// Adds the order by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="order">The order.</param>
        public void AddOrderBy(Enum field, Sorting order)
        {
            AddOrderBy(field.ToString(), order);
        }

        /// <summary>
        /// Adds the order by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="order">The order.</param>
        public void AddOrderBy(string field, Sorting order)
        {
            var newOrderByClause = new OrderByClause(field, order);
            OrderByStatement.Add(newOrderByClause);
        }

        /// <summary>
        /// Groups the by.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void GroupBy(params string[] columns)
        {
            foreach (var column in columns)
            {
                GroupByColumns.Add(column);
            }
        }

        /// <summary>
        /// Adds the having.
        /// </summary>
        /// <param name="clause">The clause.</param>
        public void AddHaving(WhereClause clause)
        {
            HavingClauses.Add(clause);
        }

        /// <summary>
        /// Adds the having.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="compareValue">The compare value.</param>
        /// <returns>The where clause.</returns>
        public WhereClause AddHaving(string field, Comparison @operator, object compareValue)
        {
            var clause = new WhereClause(null, field, @operator, compareValue);
            AddHaving(clause);

            return clause;
        }

        /// <summary>
        /// Adds the having.
        /// </summary>
        /// <param name="logicOperator">The logic operator.</param>
        /// <param name="field">The field.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="compareValue">The compare value.</param>
        /// <returns>The where clause.</returns>
        public WhereClause AddHaving(LogicOperator logicOperator, string field, Comparison @operator, object compareValue)
        {
            var clause = new WhereClause(logicOperator, field, @operator, compareValue);
            AddHaving(clause);

            return clause;
        }

        /// <summary>
        /// Sets the pagination clause.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="max">The maximum.</param>
        public void SetPaginationClause(int start, int? max)
        {
            PaginationClause = new PaginationClause
            {
                Start = start,
                Max = max
            };
        }

        /// <summary>
        /// Builds the command.
        /// </summary>
        /// <returns>The db commang.</returns>
        public DbCommand BuildCommand()
        {
            return (DbCommand)BuildQuery(true);
        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <param name="buildCommand">If set to <c>true</c> [build command].</param>
        /// <returns>The query.</returns>
        /// <exception cref="Exception">
        /// Cannot build a command when the Db Factory hasn't been specified. Call
        /// SetDbProviderFactory first. or Having statement was set without Group By.
        /// </exception>
        private object BuildQuery(bool buildCommand)
        {
            if (buildCommand && (_dbProviderFactory == null))
            {
                throw new Exception("Cannot build a command when the Db Factory hasn't been specified. Call SetDbProviderFactory first.");
            }

            DbCommand command = null;
            if (buildCommand)
            {
                command = _dbProviderFactory.CreateCommand();
            }

            var query = new StringBuilder();

            query.Append("SELECT ");

            if (Distinct)
            {
                query.Append("DISTINCT ");
            }

            if (!((TopClause.Quantity == 100) & (TopClause.Unit == TopUnit.Percent)))
            {
                query.Append("TOP " + TopClause.Quantity);
                if (TopClause.Unit == TopUnit.Percent)
                {
                    query.Append(" PERCENT");
                }

                query.Append(" ");
            }

            if (SelectedColumns.Count == 0)
            {
                if (SelectedTables.Count == 1)
                {
                    query.Append(SelectedTables[0] + ".");
                }

                query.Append("*");
            }
            else
            {
                foreach (var columnName in SelectedColumns)
                {
                    query.Append(columnName + ',');
                }

                query.TrimEnd(',');
                query.Append(' ');
            }

            if (SelectedTables.Count > 0)
            {
                query.Append(" FROM ");
                foreach (var tableName in SelectedTables)
                {
                    query.Append(tableName + ',');
                }

                query.TrimEnd(',');
                query.Append(' ');
            }

            if (JoinClauses.Count > 0)
            {
                foreach (var joinClause in JoinClauses)
                {
                    var joinString = new StringBuilder();
                    switch (joinClause.JoinType)
                    {
                        case JoinType.InnerJoin:
                            joinString.Append("INNER JOIN");
                            break;

                        case JoinType.OuterJoin:
                            joinString.Append("OUTER JOIN");
                            break;

                        case JoinType.LeftJoin:
                            joinString.Append("LEFT JOIN");
                            break;

                        case JoinType.RightJoin:
                            joinString.Append("RIGHT JOIN");
                            break;
                    }

                    joinString.Append(" " + joinClause.ToTable);

                    if (!string.IsNullOrEmpty(joinClause.ToTableAlias))
                    {
                        joinString.Append(" " + joinClause.ToTableAlias);
                    }

                    joinString.Append(" ON ");
                    joinString.Append(joinClause);

                    query.Append(joinString.ToString() + ' ');
                }
            }

            if (WhereClauses.Count > 0)
            {
                query.Append(" WHERE ");

                foreach (var clause in WhereClauses)
                {
                    query.Append(clause);
                }
            }

            if (GroupByColumns.Count > 0)
            {
                query.Append(" GROUP BY ");
                foreach (var column in GroupByColumns)
                {
                    query.Append(column + ',');
                }

                query.TrimEnd(',');
                query.Append(' ');
            }

            if (HavingClauses.Count > 0)
            {
                if (GroupByColumns.Count == 0)
                {
                    throw new Exception("Having statement was set without Group By");
                }

                query.Append(" HAVING ");

                foreach (var clause in HavingClauses)
                {
                    query.Append(clause);
                }
            }

            if (OrderByStatement.Count > 0)
            {
                query.Append(" ORDER BY ");
                foreach (var orderByClause in OrderByStatement)
                {
                    var clause = new StringBuilder();
                    switch (orderByClause.SortOrder)
                    {
                        case Sorting.Ascending:
                            clause.Append(orderByClause.FieldName + " ASC");
                            break;

                        case Sorting.Descending:
                            clause.Append(orderByClause.FieldName + " DESC");
                            break;
                    }

                    query.Append(clause.ToString() + ',');
                }

                query.TrimEnd(',');
                query.Append(' ');
            }
            else
            {
                if (PaginationClause != null)
                {
                    query.Append(" ORDER BY " + SelectedTables[0] + ".Id ASC ");
                }
            }

            if (PaginationClause != null)
            {
                query.Append("OFFSET " + PaginationClause.Start + " ROWS ");
                if (PaginationClause.Max.HasValue)
                {
                    query.Append("FETCH NEXT " + PaginationClause.Max.Value + " ROWS ONLY ");
                }
            }

            if (buildCommand && command != null)
            {
                command.CommandText = query.ToString();
                return command;
            }


            return query.ToString();
        }
    }
}