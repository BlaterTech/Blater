namespace Blater.Query.Extensions
{
    public static class ObjectQueryExtensions
    {
        /// <summary>
        /// Determines whether value is contained in the sequence provided.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="value">The value to locate in the input.</param>
        /// <param name="input">A sequence in which to locate the value.</param>
        /// <returns>true if the input sequence contains an element that has the specified value; otherwise, false.</returns>
        public static bool In<T>(this T value, IEnumerable<T> input)
        {
            return input.Contains(value);
        }

        /// <summary>
        /// Determines the field exists in the database. 
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The value to check.</param>
        /// <param name="fieldName">The name of the field to check.</param>
        /// <returns>true if the field exists; otherwise, false.</returns>
        public static bool FieldExists<T>(this T source, string fieldName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.GetType().GetProperties().Any(p => p.Name == fieldName);
        }
        
    }
}
