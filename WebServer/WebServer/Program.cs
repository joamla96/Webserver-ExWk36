using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace WebServer
{
	class Program
	{
		public static bool Running = true;
		static void Main(string[] args)
		{
			Program p = new Program();
			p.Run();
		}

		private void Run()
		{
			IPAddress ip = IPAddress.Any;
			TcpListener listener = new TcpListener(ip, 80);
			listener.Start();

			Server server = new Server(listener);
		}
	}
}
