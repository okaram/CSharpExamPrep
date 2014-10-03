using System.Net.Sockets;

class AdderServer {

  void startListeningOnPort(int port)
  {
    TcpListener l=new TcpListener(System.Net.IPAddress.Any,port);
    l.Start();
    while(true){
      TcpClient sock=l.AcceptTcpClient();

    }
  }
}
