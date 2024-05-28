using FatCat.Toolkit.Communication;
using FatCat.Toolkit.Console;

namespace TestingConsole;

public class ClientTestingWorker(ITcpFactory tcpFactory)
{
	private const ushort ServerPort = 21456;

	public async Task DoWork()
	{
		await Task.CompletedTask;

		ConsoleLog.Write($"Going to connect to TCP Server at <{ServerPort}>");

		var openClient = tcpFactory.CreateOpenTcpClient();

		await openClient.Connect("localhost", ServerPort);

		await openClient.Send("Hello from the client");
	}
}
