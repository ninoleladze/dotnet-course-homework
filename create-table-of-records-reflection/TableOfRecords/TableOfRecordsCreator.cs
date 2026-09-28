namespace TableOfRecords;

/// <summary>
/// Presents method that write in table form to the text stream a set of elements of type T.
/// </summary>
public static class TableOfRecordsCreator
{
    /// <summary>
    /// Write in table form to the text stream a set of elements of type T (<see cref="ICollection{T}"/>),
    /// where the state of each object of type T is described by public properties that have only build-in
    /// type (int, char, string etc.)
    /// </summary>
    /// <typeparam name="T">Type selector.</typeparam>
    /// <param name="collection">Collection of elements of type T.</param>
    /// <param name="writer">Text stream.</param>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="collection"/> is null.</exception>
    /// <exception cref="ArgumentNullException">Throw if <paramref name="writer"/> is null.</exception>
    /// <exception cref="ArgumentException">Throw if <paramref name="collection"/> is empty.</exception>
    public static void WriteTable<T>(ICollection<T>? collection, TextWriter? writer)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(writer);

        if (collection.Count == 0)
        {
            throw new ArgumentException("Collection is empty.", nameof(collection));
        }

        const char CornerChar = '+';
        const char HorizontalChar = '-';
        const char VerticalChar = '|';
        const int CellPadding = 2; // one space left and right

        var type = typeof(T);
        var props = type
            .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
            .OrderBy(p => p.MetadataToken)
            .ToArray();

        // Validate property types
        foreach (var prop in props)
        {
            var pt = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (!IsBuiltInType(pt))
            {
                throw new ArgumentException($"Property '{prop.Name}' is not a supported built-in type.");
            }
        }

        // Prepare rows (row-oriented: header + data rows)
        var headers = props.Select(p => p.Name).ToArray();
        var rows = new List<string[]> { headers };

        foreach (var item in collection)
        {
            var row = props.Select(p => Sanitize(FormatPropertyValue(p, item))).ToArray();
            rows.Add(row);
        }

        // Calculate column widths
        var widths = new int[props.Length];
        for (int i = 0; i < props.Length; i++)
        {
            int max = 0;
            foreach (var r in rows)
            {
                if (r[i].Length > max)
                {
                    max = r[i].Length;
                }
            }

            widths[i] = max;
        }

        // Determine alignments
        bool IsRightAlign(Type t)
        {
            var ut = Nullable.GetUnderlyingType(t) ?? t;
            var tc = System.Type.GetTypeCode(ut);
            return tc == System.TypeCode.Byte
                || tc == System.TypeCode.SByte
                || tc == System.TypeCode.Int16
                || tc == System.TypeCode.UInt16
                || tc == System.TypeCode.Int32
                || tc == System.TypeCode.UInt32
                || tc == System.TypeCode.Int64
                || tc == System.TypeCode.UInt64
                || tc == System.TypeCode.Single
                || tc == System.TypeCode.Double
                || tc == System.TypeCode.Decimal
                || tc == System.TypeCode.DateTime;
        }

        var aligns = props.Select(p => IsRightAlign(p.PropertyType)).ToArray();

        string FormatCell(string text, int width, bool right)
        {
            if (right)
            {
                return text.PadLeft(width);
            }

            return text.PadRight(width);
        }

        string BuildBorder()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(CornerChar);
            foreach (var w in widths)
            {
                sb.Append(new string(HorizontalChar, w + CellPadding));
                sb.Append(CornerChar);
            }
            return sb.ToString();
        }

        // Write table
        var border = BuildBorder();
        writer.WriteLine(border);

        // Header (left-aligned)
        void WriteRow(string[] rowValues, bool[]? rightAlign = null)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(VerticalChar);
            for (int i = 0; i < rowValues.Length; i++)
            {
                var right = rightAlign != null && rightAlign[i];
                var cell = FormatCell(rowValues[i], widths[i], right);
                sb.Append(' ');
                sb.Append(cell);
                sb.Append(' ');
                sb.Append(VerticalChar);
            }
            writer.WriteLine(sb.ToString());
        }

        WriteRow(headers);
        writer.WriteLine(border);

        // Data rows
        for (int r = 1; r < rows.Count; r++)
        {
            WriteRow(rows[r], aligns);
            writer.WriteLine(border);
        }

        writer.Flush();
    }

    private static string FormatPropertyValue(System.Reflection.PropertyInfo property, object? item)
    {
        if (item is null)
        {
            return string.Empty;
        }

        var val = property.GetValue(item);
        if (val is null)
        {
            return string.Empty;
        }

        if (val is IFormattable f)
        {
            return f.ToString(null, System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty;
        }

        return val.ToString() ?? string.Empty;
    }

    private static string Sanitize(string s)
    {
        // Replace newlines and carriage returns with spaces to keep table integrity
        return s.Replace("\r", " ", System.StringComparison.Ordinal).Replace("\n", " ", System.StringComparison.Ordinal);
    }

    private static bool IsBuiltInType(Type type)
    {
        var ut = Nullable.GetUnderlyingType(type) ?? type;
        return ut.IsPrimitive || ut == typeof(string) || ut == typeof(decimal) || ut == typeof(DateTime) || ut == typeof(char);
    }
}
