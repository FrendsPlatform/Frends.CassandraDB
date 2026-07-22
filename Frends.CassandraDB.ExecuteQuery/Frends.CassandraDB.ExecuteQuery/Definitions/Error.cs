using System;

namespace Frends.CassandraDB.ExecuteQuery.Definitions;

/// <summary>
/// Error details returned when the task fails and ThrowErrorOnFailure is false.
/// </summary>
public class Error
{
    /// <summary>
    /// Error message.
    /// </summary>
    /// <example>Connection refused</example>
    public string Message { get; internal set; }

    /// <summary>
    /// The exception that caused the error.
    /// </summary>
    /// <example>System.Exception</example>
    public Exception AdditionalInfo { get; internal set; }
}
