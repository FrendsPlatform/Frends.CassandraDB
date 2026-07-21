using System.Collections.Generic;

namespace Frends.CassandraDB.ExecuteQuery.Definitions;

/// <summary>
/// Task's result.
/// </summary>
public class Result
{
    /// <summary>
    /// True if query ran successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Query results as a list of rows, each represented as a dictionary of column name to value.
    /// Only SELECT queries contain values.
    /// </summary>
    /// <example>List { Dictionary { "column1": "value1" } }</example>
    public List<Dictionary<string, object>> QueryResults { get; private set; }

    /// <summary>
    /// Returns the server-side warnings for this query.
    /// This feature is only available for Cassandra 2.2 or above; with lower versions, this property always returns null.
    /// </summary>
    /// <example>List { "warning1", "warning2" }</example>
    public List<string> Warnings { get; private set; }

    /// <summary>
    /// Error details. Only populated when Success is false and ThrowErrorOnFailure is false.
    /// </summary>
    public Error Error { get; private set; }

    internal Result(bool success, List<Dictionary<string, object>> queryResults, List<string> warnings)
    {
        Success = success;
        QueryResults = queryResults;
        Warnings = warnings;
    }

    internal Result(Error error)
    {
        Success = false;
        Error = error;
    }
}