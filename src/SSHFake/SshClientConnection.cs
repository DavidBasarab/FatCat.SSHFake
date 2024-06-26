using System.Net.Sockets;
using FatCat.Toolkit.Communication;

namespace FatCat.SSHFake;

public class SshClientConnection(
	IFatTcpServer server,
	TcpClient client,
	string clientId,
	int bufferSize,
	IFatTcpLogger logger,
	CancellationToken cancellationToken
) : ClientConnection(server, client, clientId, bufferSize, logger, cancellationToken)
{
	protected override async Task<Stream> GetStream()
	{
		await Task.CompletedTask;

		return client.GetStream();
	}
}
