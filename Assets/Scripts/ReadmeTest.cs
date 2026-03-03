using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ReadmeTest
{
    // Test the functionality of PrintGreetings method in Readme class.
    [Test]
    public void TestPrintGreetings()
    {
        // Arrange: Create a new instance of Readme and prepare to capture log messages.
        var readme = new Readme();
        var capturedLogs = new List<string>();
        Debug.unityLogger.logHandler = (condition, stackTrace, type) => capturedLogs.Add(condition);

        // Act: Execute the method that prints greetings.
        readme.PrintGreetings();

        // Assert: Verify if the correct log message is present in the output.
        Assert.IsTrue(capturedLogs.Contains("Welcome to the Unity Tutorial!"), "Expected greeting message was not found in logs.");
    }
}