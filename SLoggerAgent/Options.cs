using CommandLine;

namespace SLoggerAgent;

public class Options
{
    [Option('s', "Server", Required = true, HelpText = "The IP address of the SLoggerServer")]
    public string serverIP { get; set; }
    [Option('p', "Port", Required = true, HelpText = "The Port of the SLoggerServer")]
    public int serverPort { get; set; }
}