using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Blater.Logging;

public class InvocationContextEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (!logEvent.Properties.ContainsKey(Constants.SourceContextPropertyName))
        {
            return;
        }
        
        var sourceContext = ((ScalarValue)logEvent.Properties[Constants.SourceContextPropertyName]).Value?.ToString();
        if (sourceContext == null)
        {
            return;
        }
        
        var callerFrame = GetCallerStackFrame(sourceContext);
        
        if (callerFrame == null)
        {
            return;
        }
        
        var methodName = callerFrame.GetMethod()?.Name;
        var lineNumber = callerFrame.GetFileLineNumber();
        var fileName = callerFrame.GetFileName();
        
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CallerContext", sourceContext));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CallerMemberName", methodName));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CallerFilePath", fileName));
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("CallerLineNumber", lineNumber));
    }
    
    private static StackFrame? GetCallerStackFrame(string className)
    {
        var trace = new StackTrace(true);
        var frames = trace.GetFrames();
        
        var callerFrame = frames.FirstOrDefault(f => f.GetMethod()?.DeclaringType?.FullName == className);
        
        return callerFrame;
    }
}