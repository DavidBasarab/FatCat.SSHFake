using Autofac;
using FatCat.Toolkit.Console;
using FatCat.Toolkit.Injection;

namespace FatCat.SSHFake;

public static class Program
{
	private static IConsoleUtilities consoleUtilities;

	public static string[] Args { get; set; }

	public static async Task Main(params string[] args)
	{
		await Task.CompletedTask;

		Args = args;

		ConsoleLog.LogCallerInformation = true;

		try
		{
			SystemScope.Initialize(
				new ContainerBuilder(),
				[typeof(Program).Assembly, typeof(ConsoleLog).Assembly],
				ScopeOptions.SetLifetimeScope
			);

			consoleUtilities = SystemScope.Container.Resolve<IConsoleUtilities>();

			var worker = SystemScope.Container.Resolve<LearningWorker>();

			await worker.DoWork();

			consoleUtilities.WaitForExit();
		}
		catch (Exception ex)
		{
			ConsoleLog.WriteException(ex);
		}
	}
}
