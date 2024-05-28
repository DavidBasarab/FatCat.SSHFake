using FatCat.Toolkit.Console;

namespace TestingConsole;

public class ClientTestingWorker
{
	public async Task DoWork()
	{
		await Task.CompletedTask;

		ConsoleLog.Write("Hello World");
	}
}
