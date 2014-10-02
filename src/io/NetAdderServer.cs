using System.Net.Sockets;
using System.Net;
using System.Linq;

class AdderServer {
  static void StartListeningOnPort(int port) {
    TcpListener l=new TcpListener(IPAddress.Any,port);
    while(true)
      {
        TcpClient c=l.AcceptTcpClient();
        var data = new System.Byte[256];

        // String to store the response ASCII representation.
        string responseData = System.String.Empty;

        // Read the first batch of the TcpServer response bytes.
        int bytes = c.GetStream().Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes-1);//skip the last \n
        int sum=responseData.Split(' ').Select(x => int.Parse(x)).Sum();
        c.GetStream().Write(
      }
  }  
}
