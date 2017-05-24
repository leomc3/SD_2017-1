namespace csharp grafo_thrift

struct aresta{
1: i32 vertice_ini
2: i32 vertice_fim
3: bool bidirecional
4: double peso
5: string desc
}

struct vertice{
1: i32 nome
2: i32 cor
3: string desc
4: double peso
}

struct grafo{
1: list<vertice> Lvertices
2: list<aresta> Larestas
}

service grafo_thrift_service
{
	bool add_vertice(1:vertice v),
	bool delet_vertice(1:vertice v),
	bool updt_vertice(1:vertice v),
	bool add_aresta(1:aresta a),
	bool delet_aresta(1:aresta a),
	bool updt_aresta(1:aresta a),
	bool lisVizVertice(1: vertice v),
	bool listvertices(1: vertice v),
	bool BuscaMenorCaminho(1: vertice a 2: vertice b),
	bool list_ArestasDoVertices(1: vertice v),
	bool list_conteudoDosVertice(),
	bool list_conteudoDoVertice(1: vertice v),
	bool list_conteudoDasArestas()
}