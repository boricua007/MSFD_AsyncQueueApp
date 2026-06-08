# MSFD AsyncQueueApp

## Overview

MSFD AsyncQueueApp is a .NET console application that demonstrates asynchronous background task processing using an in-memory queue.

The app uses `System.Threading.Channels` to queue work items and process them on a background worker while the main thread remains responsive for user input.

## Features

- Asynchronous producer-consumer workflow using `Channel<Func<Task>>`
- Background worker continuously processes queued tasks
- Main thread remains interactive while tasks run
- Graceful stop behavior via `exit` command
- Clean separation of concerns across queue, worker, and entry point classes

## Getting Started

1. Clone or download the project.
2. Open the folder in Visual Studio Code, Visual Studio, or your preferred C# IDE.
3. Restore dependencies (if prompted):

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run --project MSFD_AsyncQueueApp.csproj
   ```

5. While tasks are processing, type messages in the console.
6. Type `exit` and press Enter to stop accepting input.

## Project Structure

```text
MSFD_AsyncQueueApp/
|
|- Program.cs               # App entry point, enqueues demo tasks, handles user input
|- TaskQueue.cs             # Channel-backed async queue for Func<Task> work items
|- BackgroundWorker.cs      # Background consumer that executes queued tasks
|- MSFD_AsyncQueueApp.csproj # .NET project file and package references
```

## Key Concepts Demonstrated

- Producer-consumer pattern with channels
- Asynchronous task queuing and execution
- Decoupling task submission from task execution
- Keeping UI/input loop responsive during background processing
- Coordinating app lifetime with async worker completion

## Usage

- At startup, the app enqueues five sample tasks.
- Each task logs start/completion messages and simulates work with delay.
- The worker processes tasks one at a time from the queue.
- The main thread keeps prompting for input while tasks run.
- Enter `exit` to end input mode and wait for background processing to finish.

## About

.NET 10 console application built for the Microsoft Performance Optimization and Scalability course as part of the Microsoft Full-Stack Developer Certification track. This project demonstrates practical asynchronous task queue processing, background worker coordination, and responsive main-thread interaction patterns.

## Author

Daisy Viruet-Allen (boricua007)  
GitHub: https://github.com/boricua007
