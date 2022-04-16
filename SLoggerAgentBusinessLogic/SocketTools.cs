using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SLoggerBusinessLogic;

public class SocketTools
{
    /// <summary>
    /// This method is used to connect to a Server
    /// Socket running the SLogger Server Service
    /// </summary>
    /// <param name="server">The server address or ip of the SLogger Service is running on</param>
    /// <param name="port">The server port of the server the SLogger Service is running on</param>
    /// <returns>The Socket Object which gets created for the new connection</returns>
    private static Socket ConnectSocket(string server, int port)
    {
        Socket? socket = null;
        IPHostEntry? hostEntry = null;
        hostEntry = Dns.GetHostEntry(server);
        foreach(var address in hostEntry.AddressList)
        {
            var ipe = new IPEndPoint(address, port);
            var tempSocket =
                new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            tempSocket.Connect(ipe);

            if(tempSocket.Connected)
            {
                socket = tempSocket;
                break;
            }
        }
        return socket;
    }
    
    /// <summary>
    /// This method is used to send data to the Socket running on the
    /// SLoggerServer Service 
    /// </summary>
    /// <param name="server">The server address or ip of the SLogger service is running on</param>
    /// <param name="port">The server port of the server the SLogger service is running on</param>
    /// <param name="data">The data you want to send to the SLoggerServer service</param>
    /// <returns>The data response which was send back by the server</returns>
    private static string SocketSendReceive(string server, int port, string data)
    {
        var bytesSent = Encoding.UTF8.GetBytes(data);
        var bytesReceived = new byte[256];
        var result = "";

        // Create a socket connection with the specified server and port.
        using(var socket = ConnectSocket(server, port)) {

            if (socket == null)
            {
                return ("Connection failed");
            }
            socket.Send(bytesSent, bytesSent.Length, 0);
            var bytes = 0;
            do {
                bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);
                result = result + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);
        }
        return result;
    }

}