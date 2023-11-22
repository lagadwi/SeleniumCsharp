using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

public class ReportHelper
{
    private static ExtentReports extent;
    private static ExtentTest test;

    public static void InitializeReport()
    {
        var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtentReport.html");
        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    public static void StartTest(string testName)
    {
        test = extent.CreateTest(testName);
    }

    public static void LogTestResult(Status status, string details)
    {
        test.Log(status, details);
    }

    public static void FinalizeReport()
    {
        extent.Flush();
    }
}