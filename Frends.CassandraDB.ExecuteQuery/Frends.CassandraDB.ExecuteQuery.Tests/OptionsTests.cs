using Microsoft.VisualStudio.TestTools.UnitTesting;
using Frends.CassandraDB.ExecuteQuery.Definitions;

namespace Frends.CassandraDB.ExecuteQuery.Tests;

[TestClass]
public class OptionsTests
{
    private static readonly Input _badInput = new()
    {
        ContactPoints = new[] { new ContactPoint { Value = "127.0.0.1" } },
        Port = 19999, // unlikely to have anything listening here
        Keyspace = null,
        Query = "SELECT 1",
    };

    [TestMethod]
    public void ExecuteQuery_ThrowErrorOnFailure_False_ReturnsErrorResult()
    {
        var options = new Options { ThrowErrorOnFailure = false };

        var result = CassandraDB.ExecuteQuery(_badInput, options, default);

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.IsFalse(string.IsNullOrEmpty(result.Error.Message));
        Assert.IsNotNull(result.Error.AdditionalInfo);
        Assert.IsNull(result.QueryResults);
    }

    [TestMethod]
    public void ExecuteQuery_ThrowErrorOnFailure_True_Throws()
    {
        var options = new Options { ThrowErrorOnFailure = true };

        Assert.ThrowsException<Exception>(() => CassandraDB.ExecuteQuery(_badInput, options, default));
    }

    [TestMethod]
    public void ExecuteQuery_ThrowErrorOnFailure_True_CustomMessage_ThrowsWithCustomMessage()
    {
        var options = new Options
        {
            ThrowErrorOnFailure = true,
            ErrorMessageOnFailure = "Custom error message"
        };

        var ex = Assert.ThrowsException<Exception>(() => CassandraDB.ExecuteQuery(_badInput, options, default));

        Assert.AreEqual("Custom error message", ex.Message);
    }

    [TestMethod]
    public void ExecuteQuery_ThrowErrorOnFailure_False_CustomMessage_ReturnsErrorResultWithCustomMessage()
    {
        var options = new Options
        {
            ThrowErrorOnFailure = false,
            ErrorMessageOnFailure = "Custom error message"
        };

        var result = CassandraDB.ExecuteQuery(_badInput, options, default);

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.IsTrue(result.Error.Message.StartsWith("Custom error message"));
    }
}
