using System;
using System.Threading.Channels;
using System.Threading.Tasks;

public class TaskQueue
{
    private readonly Channel<Func<Task>> _queue;


    // Constructor initializes the channel for task management
    public TaskQueue()
    {
        _queue = Channel.CreateUnbounded<Func<Task>>();
    }

    // EnqueueAsync adds a new task to the queue for processing
    public async Task EnqueueAsync(Func<Task> task)
    {
        await _queue.Writer.WriteAsync(task);
    }

    // DequeueAsync retrieves the next task from the queue for execution
    public async Task<Func<Task>> DequeueAsync()
    {
        return await _queue.Reader.ReadAsync();
    }

    // GetReader provides access to the channel's reader for task processing
    public ChannelReader<Func<Task>> GetReader()
    {
        return _queue.Reader;
    }
}