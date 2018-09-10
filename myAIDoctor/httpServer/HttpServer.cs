using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace aiDoctor.httpServer
{
    public class HttpServer
    {
        Thread serverThread;
        TcpListener listener;
        public HttpServer(int port,Func<CompactRequest, CompactResponse> reqProc)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                serverThread = new Thread(() =>
                {
                    listener.Start();
                    while (true)
                    {
                        Socket s = listener.AcceptSocket();
                        if (s.Connected)
                        {
                            NetworkStream ns = new NetworkStream(s);
                            CompactRequest req = new CompactRequest(ns);
                            CompactResponse resp = reqProc(req);
                            StreamWriter sw = new StreamWriter(ns);
                            sw.WriteLine("HTTP/1.1 {0}", resp.StatusText);
                            sw.WriteLine("Content-Type: " + resp.ContentType);
                            foreach (string k in resp.Headers.Keys)
                            {
                                sw.WriteLine("{0}: {1}", k, resp.Headers[k]);
                            }
                            sw.WriteLine("Content-Length: {0}", resp.Data.Length);
                            sw.WriteLine();
                            sw.Flush();
                            sw.Dispose();
                            sw.Close();
                            ns.Dispose();
                            ns.Close();
                            s.Send(resp.Data);
                            //s.Shutdown(SocketShutdown.Both);
                            s.Dispose();
                            s.Close();
                        }
                    }
                });
                serverThread.Start();
            }
            catch {
                if (listener != null) {
                    listener.Stop();
                }
                if (serverThread != null)
                {
                    serverThread.Abort();
                }
            }
        }
        public void Stop()
        {
            listener.Stop();
            serverThread.Abort();
        }

    }
}
