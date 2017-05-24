using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace grafo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                trabSD hwServer = new trabSD();
                grafo_thrift.grafo_thrift_service.Processor processor = new grafo_thrift.grafo_thrift_service.Processor(hwServer);
                TServerTransport serverTransport = new TServerSocket(9090);
                TServer server = new TThreadPoolServer(processor, serverTransport);
                Console.WriteLine("Servidor carregado...");
                server.Serve();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Finalizado!");
        }
    }
}
