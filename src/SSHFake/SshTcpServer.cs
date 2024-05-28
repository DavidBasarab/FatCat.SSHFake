using System.Net.Sockets;
using FatCat.Toolkit;
using FatCat.Toolkit.Communication;

namespace FatCat.SSHFake;

public class SshTcpServer(IGenerator generator, IFatTcpLogger logger)
	: FatTcpServer(generator, logger),
		IFatTcpServer
{
	protected override ClientConnection GetClientConnection(TcpClient client, string clientId)
	{
		return new SshClientConnection(this, client, clientId, bufferSize, logger, cancelToken);
	}
}
