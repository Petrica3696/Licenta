using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations
{
    /// <summary>
    /// The SqlLiteral class.
    /// </summary>
    public class SqlLiteral
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlLiteral" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public SqlLiteral(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
}
