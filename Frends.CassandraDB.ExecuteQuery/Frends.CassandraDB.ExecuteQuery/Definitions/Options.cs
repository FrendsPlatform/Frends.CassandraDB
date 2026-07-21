using System.ComponentModel;

namespace Frends.CassandraDB.ExecuteQuery.Definitions;

/// <summary>
/// Options for the task.
/// </summary>
public class Options
{
    /// <summary>
    /// Throw an exception if the task fails.
    /// If set to false, the task will return a Result with Success set to false and Error populated.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Optional custom error message to use instead of the exception message when the task fails.
    /// </summary>
    /// <example>An error occurred while executing the query.</example>
    public string ErrorMessageOnFailure { get; set; }
}
