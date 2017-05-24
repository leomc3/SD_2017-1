using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grafo_thrift;
using System.Threading;
namespace grafo
{
    public class trabSD : grafo_thrift_service.Iface
    {
        public grafo_thrift.grafo Grafo;
        private object blocker = new object();
        public trabSD()
        {
            Grafo = new grafo_thrift.grafo();
            Grafo.Larestas = new List<aresta>();
            Grafo.Lvertices = new List<vertice>();
        }

        public bool add_aresta(aresta a)
        {
            try
            {

                //verifica si ambos os vertices da aresta são validos.
                if ((Grafo.Lvertices.Where(q => q.Nome == a.Vertice_ini).FirstOrDefault() != null) &&
                    (Grafo.Lvertices.Where(q => q.Nome == a.Vertice_fim).FirstOrDefault() != null))
                {
                    lock (blocker)
                    {
                        Grafo.Larestas.Add(a);
                        //Thread.Sleep(10000);
                    }
                }
                else
                {
                   Console.WriteLine("Aresta não cadastrada");
                    return false;
                }

                Console.WriteLine("Aresta cadastrado com sucesso");
                return true;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Aresta nao cadastrado. " + ex.Message);
                return false;
            }

        }

        public bool add_vertice(vertice v)
        {
            try
            {
                lock (blocker)
                {
                    //só pode ser adicionado si não possuir vertice com mesmo nome
                    if (Grafo.Lvertices.Where(q => q.Nome == v.Nome).FirstOrDefault() == null)
                    {
                        Grafo.Lvertices.Add(v);
                        Console.WriteLine("Vertice cadastrado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possivel o cadastrado do vertice");
                    }

                }
                return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Vertice nao cadastrado. " + ex.Message);
                return false;
            }

        }

        public bool delet_aresta(aresta a)
        {
            try
            {

                lock (blocker)
                {
                    foreach (aresta item in Grafo.Larestas)
                    {

                        if (item.Vertice_ini == a.Vertice_ini && item.Vertice_fim == a.Vertice_fim)
                        {
                            Grafo.Larestas.Remove(item);
                        }
                    }
                }
                Console.WriteLine("Aresta removida com sucesso");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Aresta nao removida. " + ex.Message);
                return false;
            }
        }

        public bool delet_vertice(vertice v)
        {
            try
            {

                lock (blocker)
                {
                    foreach (aresta item in Grafo.Larestas)
                    {

                        if (item.Vertice_ini == v.Nome || item.Vertice_fim == v.Nome)
                        {
                            Grafo.Larestas.Remove(item);
                        }
                    }

                    Grafo.Lvertices.Remove(v);
                }
                Console.WriteLine("Vertice removido com sucesso");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Vertice nao removido. " + ex.Message);
                return false;
            }
        }



        public bool updt_aresta(aresta a)
        {

            try
            {

                lock (blocker)
                {
                    aresta a1 = Grafo.Larestas.Where(q => q.Vertice_ini == a.Vertice_ini && q.Vertice_fim == a.Vertice_fim).FirstOrDefault();

                    int indice = Grafo.Larestas.IndexOf(a1);

                    Grafo.Larestas[indice].Peso = a.Peso;
                    Grafo.Larestas[indice].Bidirecional = a.Bidirecional;
                    Grafo.Larestas[indice].Desc = a.Desc;
                }
                Console.WriteLine("Aresta atualizado com sucesso");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Aresta nao nao atualizada. " + ex.Message);
                return false;
            }

        }


        public bool updt_vertice(vertice v)
        {

            try
            {

                lock (blocker)
                {
                    vertice v1 = Grafo.Lvertices.Where(p => p.Nome == v.Nome).FirstOrDefault();

                    int indice = Grafo.Lvertices.IndexOf(v1);

                    Grafo.Lvertices[indice].Cor = v.Cor;
                    Grafo.Lvertices[indice].Desc = v.Desc;
                    Grafo.Lvertices[indice].Peso = v.Peso;
                }
                Console.WriteLine("Vertice atualizado com sucesso");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Vertice nao nao atualizado. " + ex.Message);
                return false;
            }

        }

        

        public bool lisVizVertice(vertice v)
        {

            List<vertice> vizinhos = new List<vertice>();

            List<aresta> arestas = null;

            //Todas as arestas do vertice
            arestas = Grafo.Larestas.Where(p => p.Vertice_ini == v.Nome || p.Vertice_fim == v.Nome).ToList();

            if (arestas != null)
            {
                foreach (aresta item in arestas)
                {
                    if (item.Vertice_ini == v.Nome)
                    {
                        vizinhos.Add(Grafo.Lvertices.Where(p => p.Nome == item.Vertice_fim).FirstOrDefault());
                    }
                    else
                    {
                        vizinhos.Add(Grafo.Lvertices.Where(p => p.Nome == item.Vertice_ini).FirstOrDefault());
                    }
                }
            }

            Console.WriteLine("vizinhos do: " + v.Nome + " ");
            foreach (vertice item in vizinhos)
            {
                Console.WriteLine(item.Nome + " ");
            }

            return true;
        }

        public bool listvertices(vertice v)
        {
            foreach (vertice item in Grafo.Lvertices)
            {
                Console.WriteLine(item.Nome);

            }
            return true;
        }
        public bool list_ArestasDoVertices(vertice v)
        {

            List<aresta> _Arestas = new List<aresta>();
            _Arestas = Grafo.Larestas.Where(p => p.Vertice_ini == v.Nome || p.Vertice_fim == v.Nome).ToList();

            foreach(aresta item in _Arestas)
            {

                Console.WriteLine(item.Vertice_fim);
                Console.WriteLine(item.Vertice_ini);
            }
            return true;
        }

        public bool BuscaMenorCaminho(vertice origem, vertice destino)
        {
            List<vertice> visitados = new List<vertice>();
            List<Dijkstra> alg = new List<Dijkstra>();
            int aux1 = origem.Nome;
            int aux2 = destino.Nome;
            origem = Grafo.Lvertices.Where(p => p.Nome == aux1).FirstOrDefault();
            destino = Grafo.Lvertices.Where(p => p.Nome == aux2).FirstOrDefault();

            vertice atual;

            foreach (vertice item in Grafo.Lvertices)
            {

                alg.Add(new Dijkstra()
                {
                    vertice = item,
                    estimativa = (item.Nome == origem.Nome ? 0 : Int32.MaxValue),
                    precedente = null,
                    visitado = false
                });
            }

            while (visitados.Count < Grafo.Lvertices.Count)
            {
                alg = alg.OrderBy(p => p.estimativa).ToList();

                Dijkstra controleV1 = alg.Where(p => p.visitado == false).FirstOrDefault();

                if (controleV1 == null)
                {
                    break;
                }

                atual = controleV1.vertice;

                //Setar vértice como visitado
                Dijkstra controleAtual = alg.Where(p => p.vertice.Nome == atual.Nome).FirstOrDefault();
                int indiceAtual = alg.IndexOf(controleAtual);
                alg[indiceAtual].visitado = true;
                visitados.Add(atual);

                //Regra
                //Encontrar todos os vértices não visitados adjacentes ao vértice atual
                List<aresta> arestasAdjacentes = new List<aresta>(); //Lista de arestas adjacentes não visitados

                foreach (aresta item in Grafo.Larestas)
                {
                    if (item.Bidirecional && (item.Vertice_ini == atual.Nome || item.Vertice_fim == atual.Nome))
                    {
                        //Aresta indo
                        arestasAdjacentes.Add(item);

                        //Vamos inverter a aresta para simular o bidirecionamento, aresta vindo
                        arestasAdjacentes.Add(new aresta()
                        {
                            Vertice_ini = item.Vertice_fim,
                            Vertice_fim = item.Vertice_ini,
                            Bidirecional = item.Bidirecional,
                            Peso = item.Peso,
                            Desc = "I" + item.Desc
                        });
                    }
                    else if (!item.Bidirecional && (item.Vertice_ini == atual.Nome))
                    {
                        arestasAdjacentes.Add(item);
                    }
                }

                foreach (aresta item in arestasAdjacentes)
                {
                    //Vamos considerar inicialmente só o caso de ser direcionado
                    vertice v = Grafo.Lvertices.Where(p => p.Nome == item.Vertice_fim).FirstOrDefault();

                    //Se o vértice não foi visitado adiciona na lista
                    if (!visitados.Contains(v))
                    {
                        //Calcular a estimativa dos vértice adjacente
                        Dijkstra verticeAdj = alg.Where(p => p.vertice.Nome == v.Nome).FirstOrDefault();
                        int indice = alg.IndexOf(verticeAdj);

                        double estimativaCalculada = controleAtual.estimativa + item.Peso;

                        if (alg[indice].estimativa > estimativaCalculada)
                        {
                            alg[indice].estimativa = estimativaCalculada;
                            alg[indice].precedente = atual;
                        }
                    }
                }
            }

            vertice final = destino;
            List<vertice> caminho = new List<vertice>();
            while (final.Nome != origem.Nome)
            {
                caminho.Insert(0, final);

                Dijkstra aux3 = alg.Where(p => p.vertice.Desc == final.Desc).FirstOrDefault();

                final = aux3.precedente;
            }

            caminho.Insert(0, origem);

            foreach (vertice item in caminho)
            {
                Console.Write(item.Nome + " - ");
            }

            return true;
        }

         

        public bool list_conteudoDosVertice()
        {
            Console.Clear();

            Console.WriteLine("----------Vertices----------");
            Console.WriteLine("nome\t cor\t peso\t descrição");
            foreach (vertice item in Grafo.Lvertices)
            {
                Console.WriteLine(item.Nome + " - \t" + item.Cor + " -\t " + item.Peso + " -\t " + item.Desc);
            }
                return true;
        }

        public bool list_conteudoDoVertice(vertice v)
        {

            Console.WriteLine("nome\t cor\t peso\t descrição");
            vertice item = Grafo.Lvertices.Where(q => q.Nome == v.Nome).FirstOrDefault();
            Console.WriteLine(item.Nome + " - " + item.Cor + " - " + item.Peso + " - " + item.Desc);
            return true;
        }

        public bool list_conteudoDasArestas()
        {

            // Console.Clear();
            Console.WriteLine("----------Arestas----------");
            Console.WriteLine("Ant\t Prox\t Peso\t Descrição");
                foreach (aresta item in Grafo.Larestas)
                {
                    Console.WriteLine(item.Vertice_ini + " - \t" + item.Vertice_fim + " -\t " + item.Peso + " -\t " + item.Desc);
                }
                return true;
            
        }

        public class Dijkstra
        {
            public vertice vertice;
            public double estimativa;
            public vertice precedente;
            public bool visitado = false;
        }
    }
}
