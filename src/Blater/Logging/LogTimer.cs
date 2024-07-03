using System.Diagnostics;
using Serilog;

namespace Blater.Logging;

public class LogTimer(string message = "") : IDisposable
{
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _stopwatch.Stop();
            Print();
        }
    }
    
    [Conditional("DEBUG")]
    private void Print()
    {
        Log.Debug("Completed {Message} in {StopwatchElapsedMilliseconds} ms", message, _stopwatch.ElapsedMilliseconds);
        //Console.WriteLine($"Completed {message} in {_stopwatch.ElapsedMilliseconds} ms");
    }
}