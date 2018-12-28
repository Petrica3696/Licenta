using System.Text;

namespace BusinessLogic.Read.Common.QueryBuilder.Implementations.Extensions
{
    /// <summary>
    /// String Builder Extensions.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Trims the end.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <param name="endCharacter">The end character.</param>
        /// <returns>The builder formatted.</returns>
        public static StringBuilder TrimEnd(this StringBuilder sb, char endCharacter)
        {
            if (sb == null || sb.Length == 0)
            {
                return sb;
            }

            var i = sb.Length - 1;
            for (; i >= 0; i--)
            {
                if (endCharacter != sb[i])
                {
                    break;
                }
            }

            if (i < sb.Length - 1)
            {
                sb.Length = i + 1;
            }

            return sb;
        }
    }
}