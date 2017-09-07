using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Browser
{
	class Program
	{
		static void Main(string[] args)
		{
			Program p = new Program();
			p.Run();
		}

		private void Run()
		{
			TcpClient server = new TcpClient("webservicedemo.datamatiker-skolen.dk", 80);
			StreamWriter sw = new StreamWriter(server.GetStream());
			StreamReader sr = new StreamReader(server.GetStream());

			sw.WriteLine("GET /RegneWcfService.svc/RESTjson/Add?a={0}&b={1} HTTP/1.1", 1, 5);
			sw.WriteLine("Host: webservicedemo.datamatiker-skolen.dk");
			sw.WriteLine();
			sw.Flush();

			string response = sr.ReadLine();
			Console.WriteLine(response);

			if(response == "HTTP/1.1 200 OK")
			{
				string header;
				int ContentLength = 0;
				do
				{
					header = sr.ReadLine();
					string[] headerArr = header.Split(':');
					if(headerArr[0] == "Content-Length")
					{
						ContentLength = int.Parse(headerArr[1]);
					}
					Console.WriteLine(header);
				} while (header.Length != 0);

				for(int i = 0; i < ContentLength; i++)
				{
					char res = (char)sr.Read();
					Console.Write(res);
				}
			}

			Console.ReadKey();
		}
	}
}
