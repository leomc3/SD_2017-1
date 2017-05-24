using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grafo_thrift;
namespace ConsoleApp1
{
    public class grafo_cliente
    {

        public static void InserirVertice(grafo_thrift_service.Client client)
        {
            vertice v = new vertice();

            Console.Write("Informe o nome do vértice: ");
            v.Nome = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a cor do vértice: ");
            v.Cor = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o peso do vértice: ");
            v.Peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("Informe a descrição do vértice: ");
            v.Desc = Console.ReadLine();

            client.add_vertice(v);
        }

        public static void RemoverVertice(grafo_thrift_service.Client client)
        {

            int nomeVerticeRemover;

            Console.Write("Informe o nome do vértice a ser removido: ");
            nomeVerticeRemover = Convert.ToInt32(Console.ReadLine());

            vertice v = new vertice();
            v.Nome = nomeVerticeRemover;

            client.delet_vertice(v);
        }


        public static void AtualizarVertice(grafo_thrift_service.Client client)
        {

            vertice v = new vertice();

            Console.Write("Informe o nome do vértice a ser atualizada: ");
            v.Nome = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o novo valor da cor do vértice: ");
            v.Cor = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o novo peso do vértice: ");
            v.Peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("Informe a nova descrição do vértice: ");
            v.Desc = Console.ReadLine();

            client.updt_vertice(v);

        }


        public static void InserirAresta(grafo_thrift_service.Client client)
        {
            aresta a = new aresta();

            Console.Write("Informe o vertice inicial: ");
            a.Vertice_ini = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe a vertice final: ");
            a.Vertice_fim = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe si e Bidirecional: ");
            a.Bidirecional = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Informe o peso do vértice: ");
            a.Peso = Convert.ToDouble(Console.ReadLine());
                
            Console.Write("Informe a descrição do vértice: ");
            a.Desc = Console.ReadLine();
            

            client.add_aresta(a);
        }



        public static void RemoverAresta(grafo_thrift_service.Client client)
        {

            int ini, fim;
            Console.Write("--Removendo aresta --- ");
            Console.Write("Informe o primeiro vertece que liga a aresta ");
            ini = Convert.ToInt32(Console.ReadLine());


            Console.Write("Informe o segundo vertece que liga a aresta ");
            fim = Convert.ToInt32(Console.ReadLine());

            aresta a = new aresta();
            a.Vertice_fim = fim;
            a.Vertice_ini = ini;
            client.delet_aresta(a);
        }

        public static void AtualizarAresta(grafo_thrift_service.Client client)
        {
            aresta a = new aresta();

            Console.Write("Informe o nome novo valor, é bidirecional?");
            a.Bidirecional = Convert.ToBoolean(Console.ReadLine());
            
            Console.Write("Informe o novo peso da aresta: ");
            a.Peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("Informe a nova descrição da aresta: ");
            a.Desc = Console.ReadLine();

            client.updt_aresta(a);

        }

        public static void  list_ArestasDoVertices(grafo_thrift_service.Client client)
        {
            vertice v = new vertice();
            Console.Write("Informe o nome do vértice: ");
            v.Nome = Convert.ToInt32(Console.ReadLine());

            client.list_ArestasDoVertices(v);
        }

        

            public static void list_conteudoDosVertice(grafo_thrift_service.Client client)
        {
            
            client.list_conteudoDosVertice();
        }

        public static void list_conteudoDasArestas(grafo_thrift_service.Client client)
        {

            client.list_conteudoDasArestas();
        }


        public static void list_conteudoDoVertice(grafo_thrift_service.Client client)
        {
            vertice v = new vertice();
            Console.Write("Informe o nome do vértice: ");
            v.Nome = Convert.ToInt32(Console.ReadLine());

            client.list_conteudoDoVertice(v);
        }

        public static void ListarVizinhos(grafo_thrift_service.Client client)
        {
            vertice v = new vertice();
            Console.Write("Informe o nome do vértice: ");
            v.Nome = Convert.ToInt32(Console.ReadLine());

            client.lisVizVertice(v);
        }

        public static void ListarVertices(grafo_thrift_service.Client client)
        {
            vertice v = new vertice();
            v.Desc = "a";
            
            client.listvertices(v);
        }

        public static void Busca_menor(grafo_thrift_service.Client client)
        {
            vertice v1, v2;
            v1 = new vertice();
            v2 = new vertice();
            Console.WriteLine("Infome o nome do primeiro vertice: ");
            v1.Nome = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Infome o nome do segundo vertice: ");
            v2.Nome = Convert.ToInt32(Console.ReadLine());

            client.BuscaMenorCaminho(v1, v2);
            return;
        }

    }

    
}
