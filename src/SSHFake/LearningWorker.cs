using System.Text;
using FatCat.Toolkit;
using FatCat.Toolkit.Communication;
using FatCat.Toolkit.Console;

namespace FatCat.SSHFake;

public class LearningWorker
{
	private const ushort ServerPort = 21456;

	public async Task DoWork()
	{
		await Task.CompletedTask;

		var server = new SshTcpServer(new Generator(), new ConsoleFatTcpLogger());

		server.TcpMessageReceivedEvent += data =>
		{
			var message = Encoding.UTF8.GetString(data);

			ConsoleLog.Write(message);
		};

		ConsoleLog.WriteYellow($"Going to start server on port <{ServerPort}>");

		server.Start(ServerPort, Encoding.UTF8);

		ConsoleLog.WriteGreen($"Listening on port <{ServerPort}>");
	}
}
