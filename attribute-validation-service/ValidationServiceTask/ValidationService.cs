using System.Reflection;
using ValidationAttributes;

namespace ValidationServiceTask;

/// <summary>
/// A generic validation service that validates objects of type T using custom validation attributes.
/// </summary>
/// <typeparam name="T">The type of object to validate.</typeparam>
public class ValidationService<T>
    where T : class
{
    private Dictionary<string, List<ValidationResult>> validationInfo = new ();

    /// <summary>
    /// Gets the validation information for the last validated object.
    /// This is a dictionary mapping member names to lists of validation results.
    /// </summary>
    public Dictionary<string, List<ValidationResult>> ValidationInfo => this.validationInfo;

    /// <summary>
    /// Validates an object of type T and determines if it is valid.
    /// </summary>
    /// <param name="obj">The object to validate.</param>
    /// <returns>true if the object is valid; otherwise, false.</returns>
    public bool IsValid(T obj)
    {
        this.validationInfo = new ();

        if (obj == null)
        {
            return false;
        }

        Type objectType = obj.GetType();

        // Get all properties
        PropertyInfo[] properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            this.ValidateMember(property, property.GetValue(obj));
        }

        // Get all fields
        FieldInfo[] fields = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            this.ValidateMember(field, field.GetValue(obj));
        }

        return this.validationInfo.Count == 0;
    }

    /// <summary>
    /// Validates a single member (property or field) of an object.
    /// </summary>
    private void ValidateMember(MemberInfo member, object? value)
    {
        // Get all validation attributes on this member
        var attributes = member.GetCustomAttributes<ValidationAttribute>();

        foreach (var attribute in attributes)
        {
            if (!attribute.IsValid(value))
            {
                string memberName = member.Name;
                if (!this.validationInfo.TryGetValue(memberName, out var errors))
                {
                    errors = new List<ValidationResult>();
                    this.validationInfo[memberName] = errors;
                }

                var result = new ValidationResult(attribute.GetType(), attribute.ErrorMessage);
                errors.Add(result);
            }
        }
    }
}
