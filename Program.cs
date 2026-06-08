using System;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        TaskQueue  queue = new TaskQueue();
        BackgroundWorker worker = new BackgroundWorker(queue);

        // Start the background worker to process tasks from the queue
        Task workerTask = Task.Run(() => worker.StartProcessing());

        // Enqueue several tasks to demonstrate the background processing
        for (int i = 1; i <= 5; i++)
        {
            int taskId = i;
            await queue.EnqueueAsync(async () =>
            {
                Console.WriteLine($"Task {taskId} started...");
                await Task.Delay(7000); // Simulate longer processing
                Console.WriteLine($"Task {taskId} completed.");
            });
        }

        Console.WriteLine("You can type messages while tasks are running. Type 'exit' to stop.");

        // Main thread continues to accept user input while background tasks are processed
        while (true)
        {
            Console.WriteLine("[Main Thread] Type a message and press enter:");
            string input = Console.ReadLine();
            
            if (input?.ToLower() == "exit")
                break;

            Console.WriteLine($"[Main Thread] You typed: {input.ToUpper()}");
        }

        Console.WriteLine("Main thread finished. Waiting for background tasks...");

        // Ensure all tasks finish before the program exits
        await workerTask;
    }
}
