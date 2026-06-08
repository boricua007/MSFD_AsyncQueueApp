using System;
using System.Threading.Tasks;

public class BackgroundWorker
{
    private readonly TaskQueue _taskQueue;

    public BackgroundWorker(TaskQueue taskQueue)
    {
        _taskQueue = taskQueue;
    }


    // This method continuously processes tasks from the queue
    public async Task StartProcessing()
    {
        while (await _taskQueue.GetReader().WaitToReadAsync())
        {
            var task = await _taskQueue.DequeueAsync();
            await task(); // Execute the task

        }
    }
}
