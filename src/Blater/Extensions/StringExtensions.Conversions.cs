namespace Blater.Extensions;

public static partial class StringExtensions
{
    public static Span<char> ToKebabCase(this in Span<char> input, bool onlyDots = false)
    {
        if (onlyDots)
        {
            input.Replace('.', '-');
            return input;
        }

        var output = new Span<char>();

        var j = 0;

        //If first char is uppercase, make it lowercase
        output[j++] = char.ToLower(input[0]);

        for (var i = 1; i < input.Length; i++)
        {
            var c = input[i];

            switch (c)
            {
                //Ignore dots
                case '.':
                    continue;
                //Replace spaces with dashes
                case ' ':
                    output[j++] = '-';
                    continue;
            }

            if (char.IsUpper(c))
            {
                output[j++] = '-';
                output[j++] = char.ToLower(c);
            }
            else
            {
                output[j++] = c;
            }
        }

        return output;
    }

    public static string ToKebabCase(this string inputString, bool onlyDots = false)
    {
        var input = inputString.AsSpan();
        var output = new Span<char>();
        if (onlyDots)
        {
            input.Replace(output, '.', '-');
            return new string(output);
        }

        var j = 0;

        //If first char is uppercase, make it lowercase
        output[j++] = char.ToLower(input[0]);

        for (var i = 1; i < input.Length; i++)
        {
            var c = input[i];

            switch (c)
            {
                //Ignore dots
                case '.':
                    continue;
                //Replace spaces with dashes
                case ' ':
                    output[j++] = '-';
                    continue;
            }

            if (char.IsUpper(c))
            {
                output[j++] = '-';
                output[j++] = char.ToLower(c);
            }
            else
            {
                output[j++] = c;
            }
        }

        return new string(output);
    }

    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        return char.ToLowerInvariant(str[0]) + str[1..];
    }

    public static Span<char> ToCamelCase(this Span<char> str)
    {
        if (str.Length == 0)
        {
            return str;
        }

        str[0] = char.ToLowerInvariant(str[0]);
        return str;
    }

    public static string ToFriendlyCase(this string pascalString)
    {
        if (string.IsNullOrEmpty(pascalString))
        {
            return pascalString;
        }

        var input = pascalString.AsSpan();
        var result = new char[input.Length * 2];
        var resultIndex = 0;
        result[resultIndex++] = input[0];
        for (var i = 1; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = input[i];
        }

        return new string(result, 0, resultIndex);
    }
}