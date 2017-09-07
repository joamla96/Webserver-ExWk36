using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WebServer
{
	public class Server
	{
		public Server(TcpListener listener)
		{
			Socket client = listener.AcceptSocket();
			NetworkStream ns = new NetworkStream(client);
			StreamReader sr = new StreamReader(ns);
			StreamWriter sw = new StreamWriter(ns);
			sw.AutoFlush = true;

			while (Program.Running)
			{
				string request = sr.ReadLine();
				switch (request)
				{
					case "GET / HTTP/1.1":
						string responsemsg = File.ReadAllText("./content/abc.html");

						sw.WriteLine("HTTP/1.1 200 OK");
						sw.WriteLine("Content-Type: text/html");
						sw.WriteLine("Content-Length: " + responsemsg.Length);
						sw.WriteLine();
						sw.WriteLine(responsemsg);
						break;
				}
			}
		}
	}
}
