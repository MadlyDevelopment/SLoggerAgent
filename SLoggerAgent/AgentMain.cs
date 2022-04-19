using SLoggerBusinessLogic;

namespace SLoggerAgent;

public static class AgentMain
{
    public static void Main(string[] args)
    {
        ConnectToSocketServer();
    }

    private static void ConnectToSocketServer()
    {
        var data = SocketTools.SocketSendReceive("", 11000, "");
        Console.WriteLine(data);
    }
}