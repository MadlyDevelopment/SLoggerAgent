using CommandLine;
using SLoggerBusinessLogic;

namespace SLoggerAgent;

public static class AgentMain
{
    private static Options _options { get; set; }
    
    public static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options => InitParsedValues(options))
            .WithNotParsed(errors => HandleParseError(errors));
        ConnectToSocketServer();
    }

    private static void InitParsedValues(Options obj)
    {
        _options.serverIP = obj.serverIP;
        _options.serverPort = obj.serverPort;
    }

    private static void ConnectToSocketServer()
    {
        var data = SocketTools.SocketSendReceive(_options.serverIP, _options.serverPort, "");
        Console.WriteLine(data);
    }
    
    private static void HandleParseError(IEnumerable<Error> errs)
    {
        
    }
    
}