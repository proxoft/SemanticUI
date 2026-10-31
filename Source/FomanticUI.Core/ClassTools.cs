namespace Proxoft.FomanticUI.Core;

public static class ClassTools
{
    public static string ConcatIfNotEmpty(this string prefix, string suffix)
    {
        return string.IsNullOrWhiteSpace(prefix)
            ? string.Empty
            : $"{prefix} {suffix}";
    }

    public static string ToClass(this IEnumerable<string> classes)
    {
        return string.Join(" ", classes.Where(c => !string.IsNullOrWhiteSpace(c)));
    }

    public static string ToClassIf(this string @class, bool condition, string ifFalseClass = "")
    {
        return condition ? @class : ifFalseClass;
    }

    public static string ToClassIfNot(this string @class, bool condition, string ifTrueClass = "")
    {
        return condition ? ifTrueClass : @class;
    }

    public static string ToClassIf(this bool value, string trueClass)
    {
        return value.ToClass(trueClass, string.Empty);
    }

    public static string ToClassIfNot(this bool value, string falseClass)
    {
        return value.ToClass(string.Empty, falseClass);
    }

    public static string ToClass(this bool value, string trueClass, string falseClass)
    {
        return (value ? trueClass : falseClass) ?? string.Empty;
    }

    public static void SetAsAttribute(this string? value, string attributeName, IDictionary<string, object> attributes, bool ignoreIfNull = true)
    {
        SetAttribute(attributeName, value, attributes, ignoreIfNull);
    }

    public static void SetAttribute(string attributeName, object? value, IDictionary<string, object> attributes, bool ignoreIfNull = true)
    {
        if (ignoreIfNull && value == null) return;

        // a null value is stored only when ignoreIfNull is false; Blazor omits attributes whose value is null
        if (attributes.ContainsKey(attributeName))
            attributes[attributeName] = value!;
        else
            attributes.Add(attributeName, value!);
    }
}