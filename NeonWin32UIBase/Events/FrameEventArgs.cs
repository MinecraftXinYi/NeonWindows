using System;

namespace NativeWindow.Windowing.Events;

public sealed class FrameEventArgs : EventArgs
{
    public FrameEventArgs(ulong elapsedTicks, double elapsedSeconds, ulong totalTicks, double totalSeconds, ulong frameCount, uint framesPerSecond)
    {
        ElapsedTicks = elapsedTicks;
        ElapsedSeconds = elapsedSeconds;
        TotalTicks = totalTicks;
        TotalSeconds = totalSeconds;
        FrameCount = frameCount;
        FramesPerSecond = framesPerSecond;
    }

    /// <summary>
    /// Elapsed ticks since the previous Update call.
    /// </summary>
    public ulong ElapsedTicks { get; }

    /// <summary>
    /// Elapsed time since the previous Update call, in seconds.
    /// </summary>
    public double ElapsedSeconds { get; }

    /// <summary>
    /// Total time since the start of the program.
    /// </summary>
    public ulong TotalTicks { get; }

    /// <summary>
    /// Total time in seconds since the start of the program.
    /// </summary>
    public double TotalSeconds { get; }

    /// <summary>
    /// Total number of updates since start of the program.
    /// </summary>
    public ulong FrameCount { get; }

    /// <summary>
    /// The current framerate.
    /// </summary>
    public uint FramesPerSecond { get; }
}
