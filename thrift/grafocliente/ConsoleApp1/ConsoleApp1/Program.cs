using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using grafo_thrift;

namespace ConsoleApp1
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("**MENU**");
            Console.WriteLine("1. Adiciona Aresta");
            Console.WriteLine("2. Remove Aresta");
            Console.WriteLine("3. Altera Aresta");
            Console.WriteLine("4. Adiciona Vertice");
            Console.WriteLine("5. Remove Vertice");
            Console.WriteLine("6. Altera Vertice");
            Console.WriteLine("7. Exibe vizinhos do Vertice");
            Console.WriteLine("8. Exibe nome de todos os Vertices");
            Console.WriteLine("9. Exibe menor caminho");
            Console.WriteLine("10. Exibe aresta do vertice");
            Console.WriteLine("11. Exibe conteudo dos vertice");
            Console.WriteLine("12. Exibe conteudo de um vertice");
            Console.WriteLine("13. Exibe conteudo das arestas");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Opcao: ");
        }

        static void Main(string[] args)
        {

            grafo_thrift_service.Client client;
            string opcao;
            try
            {
                TTransport transport = new TSocket("localhost", 9090);
                transport.Open();
                TProtocol protocol = new TBinaryProtocol(transport);
                client = new grafo_thrift_service.Client(protocol);

                vertice v = new vertice();
                aresta a = new aresta();
                /*
                int i;
                for (i = 0; i < 10; i++)
                {

                    v.Nome = i;
                    v.Cor = 1;
                    v.Peso = 1;
                    v.Desc = "a";
                    client.add_vertice(v);
                }
                for(i=3;i<8;i++)
                {
                    a.Vertice_ini = i;
                    a.Vertice_fim = i + 1;
                    a.Peso = i;
                    a.Bidirecional = true;
                    a.Desc = "nda";
                    client.add_aresta(a);
                }
                
    */
                #region Input

                v.Nome = 1;
                v.Cor = 1;
                v.Peso = 1;
                v.Desc = "First";
                client.add_vertice(v);

                v.Nome = 2;
                v.Cor = 4;
                v.Peso = 2;
                v.Desc = "Second";
                client.add_vertice(v);

                a.Vertice_ini = 1;
                a.Vertice_fim = 2;
                a.Peso =1;
                a.Bidirecional = true;
                a.Desc = "leve";
                client.add_aresta(a);

                v.Nome = 3;
                v.Cor = 7;
                v.Peso = 13;
                v.Desc = "MID IN";
                client.add_vertice(v);

                a.Vertice_ini = 1;
                a.Vertice_fim = 3;
                a.Peso = 5;
                a.Bidirecional = true;
                a.Desc = "pesado";
                client.add_aresta(a);
                /*mudar aq para teste de menro caminho*/
                a.Vertice_ini = 2;
                a.Vertice_fim = 3;
                a.Peso = 2;
                a.Bidirecional = true;
                a.Desc = "leve";
                client.add_aresta(a);


                v.Nome = 4;
                v.Cor = 11;
                v.Peso = 10;
                v.Desc = "MID OUT";
                client.add_vertice(v);

                a.Vertice_ini = 3;
                a.Vertice_fim = 4;
                a.Peso = 2;
                a.Bidirecional = true;
                a.Desc = "Mid";
                client.add_aresta(a);


                v.Nome = 5;
                v.Cor = 22;
                v.Peso = 15;
                v.Desc = "Penultima";
                client.add_vertice(v);

                a.Vertice_ini = 4;
                a.Vertice_fim = 5;
                a.Peso = 1;
                a.Bidirecional = true;
                a.Desc = "leve";
                client.add_aresta(a);


                v.Nome = 6;
                v.Cor = 33;
                v.Peso = 10;
                v.Desc = "Ultima";
                client.add_vertice(v);

                a.Vertice_ini = 4;
                a.Vertice_fim = 6;
                a.Peso = 5;
                a.Bidirecional = true;
                a.Desc = "pesado";
                client.add_aresta(a);

                a.Vertice_ini = 5;
                a.Vertice_fim = 6;
                a.Peso = 1;
                a.Bidirecional = true;
                a.Desc = "leve";
                client.add_aresta(a);

                #endregion

                do
                {
                    Menu();
                    opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1"://add Vertice
                            grafo_cliente.InserirAresta(client);
                            break;
                        case "2":
                            grafo_cliente.RemoverAresta(client);
                            break;
                        case "3":
                            grafo_cliente.AtualizarAresta(client);
                            break;
                        case "4":
                            grafo_cliente.InserirVertice(client);
                            break;
                        case "5":
                            grafo_cliente.RemoverVertice(client);
                            break;
                        case "6":
                            grafo_cliente.AtualizarVertice(client);
                            break;
                        case "7":
                            grafo_cliente.ListarVizinhos(client);
                            break;
                        case "8":
                            grafo_cliente.ListarVertices(client);
                            break;
                        case "9":
                            grafo_cliente.Busca_menor(client);
                            break;
                        case "10":
                            grafo_cliente.list_ArestasDoVertices(client);
                            break;
                        case "11":
                            grafo_cliente.list_conteudoDosVertice(client);
                            break;
                        case "12":
                            grafo_cliente.list_conteudoDoVertice(client);
                            break;
                        case "13":
                            grafo_cliente.list_conteudoDasArestas(client);
                            break;

                            
                    } //Fim switch
                }
                while (opcao != "0");
            



                    //grafo_cliente.InserirVertice(client);

                //    grafo_cliente.InserirAresta(client);

                //grafo_cliente.RemoverVertice(client);

                //grafo_cliente.AtualizarVertice(client);

                //grafo_cliente.ListarVizinhos(client);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
