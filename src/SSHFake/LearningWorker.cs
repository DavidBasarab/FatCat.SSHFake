using FatCat.Toolkit;
using FatCat.Toolkit.Communication;
using FatCat.Toolkit.Console;

namespace FatCat.SSHFake;

public class LearningWorker
{
	public async Task DoWork()
	{
		await Task.CompletedTask;

		ConsoleLog.Write("Hello World");
	}
}

public class SshTcpServer(IGenerator generator, IFatTcpLogger logger) : FatTcpServer(generator, logger)
{
	
}