using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rota;
using UnityEngine.UI;
using System.IO;

class Node
{
    int peso;
    String direcao;

    public void setPeso(int x)
    {
        peso = x;
    }
    public int getPeso()
    {
        return peso;
    }

    public void setDirecao(String x)
    {
        direcao = x;
    }

    public String getDirecao()
    {
        return direcao;
    }


}
class AdjacencyList
{
    LinkedList<Tuple<int, Node>>[] adjacencyList;
    List<int> caminhoSeguido = new List<int>();
    int tamanhoCaminho = 0;
    //Criar Tabela Variaveis
    double[] posicoes = new double[Tamanho];

    // Constructor - creates an empty Adjacency List
    public AdjacencyList(int vertices)
    {
        adjacencyList = new LinkedList<Tuple<int, Node>>[vertices];


        for (int i = 0; i < adjacencyList.Length; ++i)
        {
            adjacencyList[i] = new LinkedList<Tuple<int, Node>>();
        }
    }
    private int distanciaManh(int inicio, int fim)
    {
        double aux = -1;
        int x1 = -1, y1 = -1, x2 = -1, y2 = -1;
        int theEnd;

        //Primeira posicao
        aux = posicoes[inicio];
        x1 = Convert.ToInt32(aux);
        //Caso arredonde pra cima o valor.
        if (x1 > aux)
            x1 = x1 - 1;
        aux = aux - x1;
        aux = aux * 100;
        y1 = Convert.ToInt32(aux);

        //Segunda posicao
        aux = posicoes[fim];
        x2 = Convert.ToInt32(aux);
        //Caso arredonde pra cima o valor.
        if (x2 > aux)
            x2 = x2 - 1;
        aux = aux - x2;
        aux = aux * 100;
        y2 = Convert.ToInt32(aux);

        theEnd = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        return theEnd;

    }

    // Appends a new Vertice to the linked list
    public void addEdgeAtEnd(int startVertex, int endVertex, int peso,int x,int y, String dic)
    {

        Node vertice = new Node();

        double aux = Convert.ToDouble(y);
        double auxiliar = x + (aux / 10);

        if (posicoes[startVertex] == -1)
            posicoes[startVertex] = auxiliar;

        vertice.setDirecao(dic);
        vertice.setPeso(peso);

        adjacencyList[startVertex].AddLast(new Tuple<int, Node>(endVertex, vertice));
    }

    // Adds a new Edge to the linked list from the front
    public void addEdgeAtBegin(int startVertex, int endVertex, Node weight)
    {
        adjacencyList[startVertex].AddFirst(new Tuple<int, Node>(endVertex, weight));
    }

    // Returns number of vertices
    // Does not change for an object
    public int getNumberOfVertices()
    {
        return adjacencyList.Length;
    }

    // Returns a copy of the Linked List of outward edges from a vertex
    public LinkedList<Tuple<int, Node>> this[int index]
    {
        get
        {
            LinkedList<Tuple<int, Node>> edgeList
                           = new LinkedList<Tuple<int, Node>>(adjacencyList[index]);

            return edgeList;
        }
    }

    //Funcoes pra unity
    public void Esquerda(GameObject x)
    {
        var rotationVector = x.transform.rotation.eulerAngles;
        rotationVector.y = 180;
        x.transform.rotation = Quaternion.Euler(rotationVector);
    }

    public void Direita(GameObject x)
    {
        var rotationVector = x.transform.rotation.eulerAngles;
        rotationVector.y = 0;
        x.transform.rotation = Quaternion.Euler(rotationVector);
    }

    public void Cima(GameObject x)
    {
        var rotationVector = x.transform.rotation.eulerAngles;
        rotationVector.y = 270;
        x.transform.rotation = Quaternion.Euler(rotationVector);
    }

    public void Baixo(GameObject x)
    {
        var rotationVector = x.transform.rotation.eulerAngles;
        rotationVector.y = 90;
        x.transform.rotation = Quaternion.Euler(rotationVector);
    }


    // Prints the Adjacency List
    public void printAdjacencyList()
    {
        int i = 0;

        foreach (LinkedList<Tuple<int, Node>> indice in adjacencyList)
        {
            Console.Write("adjacencyList[" + i + "] -> ");

            foreach (Tuple<int, Node> aresta in indice)
            {
                Console.Write(aresta.Item1 + "(" + aresta.Item2.getPeso() + ")");
            }

            ++i;
            Console.WriteLine();
        }
    }

    public void adjacente(int indice)
    {
        LinkedList<Tuple<int, Node>> test = adjacencyList[indice];

        foreach (Tuple<int, Node> aresta in test)
        {
            Console.Write(aresta.Item1 + "(" + aresta.Item2 + ")");
        }
    }

    public int tamanho()
    {
        return (adjacencyList.Length);
    }



    // Removes the first occurence of an edge and returns true
    // if there was any change in the collection, else false
    public bool removeEdge(int startVertex, int endVertex, Node weight)
    {
        Tuple<int, Node> edge = new Tuple<int, Node>(endVertex, weight);

        return adjacencyList[startVertex].Remove(edge);
    }

    private String searchDirecao(int val1, int val2)
    {
        String aux = " ";

        int i = 0;
        int j;

        foreach (LinkedList<Tuple<int, Node>> indice in adjacencyList)
        {
            j = 0;
            foreach (Tuple<int, Node> aresta in indice)
            {
                if (i == val1 && aresta.Item1 == val2)
                {
                    aux = aresta.Item2.getDirecao();
                }
                j++;
            }

            ++i;
        }
        return aux;
    }

    private int searchPeso(int val1, int val2)
    {
        int aux = -1;

        int i = 0;
        int j;

        foreach (LinkedList<Tuple<int, Node>> indice in adjacencyList)
        {
            j = 0;
            foreach (Tuple<int, Node> aresta in indice)
            {
                if (i == val1 && aresta.Item1 == val2)
                {
                    aux = aresta.Item2.getPeso();
                }
                j++;
            }

            ++i;
        }
        return aux;
    }
    public void arrumaCaminho(GameObject[] marcador)
    {
        int[] aux = new int[tamanhoCaminho];
        caminhoSeguido.CopyTo(aux);
        string[] aux2 = new string[Tamanho];
        
        for (int i = 0; i < Tamanho; i++)
            aux2[i] = mudarTextoDirecao[i];

       mudarTextoDirecao[aux[0]] = "GO STRAIGHT AHEAD";//SIGA EM FRENTE
       Cima(marcador[indiceImagem - 1]);

        for (int i = 1; i < tamanhoCaminho; i++)
        {
            //Parte de Cima
            if (aux2[aux[i - 1]] == "SIGA EM FRENTE" && aux2[aux[i]] == "SIGA EM FRENTE")
            {
                mudarTextoDirecao[aux[i]] = "SIGA EM FRENTE";
                Cima(marcador[aux[i]]);
            }
            if (aux2[aux[i - 1]] == "SIGA EM FRENTE" && aux2[aux[i]] == "VOLTE PARA TRAS")
            {
                mudarTextoDirecao[aux[i]] = "VOLTE PARA TRAS";
                Baixo(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "SIGA EM FRENTE" && aux2[aux[i]] == "VIRE PARA ESQUERDA")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA ESQUERDA";
                Esquerda(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "SIGA EM FRENTE" && aux2[aux[i]] == "VIRE PARA DIREITA")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA DIREITA";
                Direita(marcador[aux[i]]);
            }
            //PARTE DE BAIXO
            if (aux2[aux[i - 1]] == "VOLTE PARA TRAS" && aux2[aux[i]] == "SIGA EM FRENTE")
            {
                mudarTextoDirecao[aux[i]] = "VOLTE PARA TRAS";
                Baixo(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VOLTE PARA TRAS" && aux2[aux[i]] == "VOLTE PARA TRAS")
            {
                mudarTextoDirecao[aux[i]] = "SIGA EM FRENTE";
                Cima(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VOLTE PARA TRAS" && aux2[aux[i]] == "VIRE PARA ESQUERDA")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA DIREITA";
                Direita(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VOLTE PARA TRAS" && aux2[aux[i]] == "VIRE PARA DIREITA")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA ESQUERDA";
                Esquerda(marcador[aux[i]]);
            }
            //PARTE DA ESQUERDA
            if (aux2[aux[i - 1]] == "VIRE PARA ESQUERDA" && aux2[aux[i]] == "SIGA EM FRENTE")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA DIREITA";
                Direita(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA ESQUERDA" && aux2[aux[i]] == "VOLTE PARA TRAS")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA ESQUERDA";
                Esquerda(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA ESQUERDA" && aux2[aux[i]] == "VIRE PARA ESQUERDA")
            {
                mudarTextoDirecao[aux[i]] = "SIGA EM FRENTE";
                Cima(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA ESQUERDA" && aux2[aux[i]] == "VIRE PARA DIREITA")
            {
                mudarTextoDirecao[aux[i]] = "VOLTE PARA TRAS";
                Baixo(marcador[aux[i]]);
            }
            //PARTE DA DIREITA
            if (aux2[aux[i - 1]] == "VIRE PARA DIREITA" && aux2[aux[i]] == "SIGA EM FRENTE")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA ESQUERDA";
                Esquerda(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA DIREITA" && aux2[aux[i]] == "VOLTE PARA TRAS")
            {
                mudarTextoDirecao[aux[i]] = "VIRE PARA DIREITA";
                Direita(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA DIREITA" && aux2[aux[i]] == "VIRE PARA ESQUERDA")
            {
                mudarTextoDirecao[aux[i]] = "VOLTE PARA TRAS";
                Baixo(marcador[aux[i]]);
            }

            if (aux2[aux[i - 1]] == "VIRE PARA DIREITA" && aux2[aux[i]] == "VIRE PARA DIREITA")
            {
                mudarTextoDirecao[aux[i]] = "SIGA EM FRENTE";
                Cima(marcador[aux[i]]);
            }

        }

    }

    public void aEstrela(int inicio, int fim, int tamanho, GameObject[] marcador, List<int> path)
    {
        int[] caminho = new int[tamanho];//Vetor de anteriores
        int[] custo = new int[tamanho];//Vetor G.
        int[] distanciaH = new int[tamanho];//Vetor H.
        int[] f = new int[tamanho];//Vetor F.

        int aux, menorG, auxF;
        int aux2 = inicio;

        for (int j = 0; j < tamanho; j++)
        {
            custo[j] = -1;
            f[j] = -1;
            caminho[j] = -1;
        }

        caminho[inicio] = 0;
        custo[inicio] = 0;
        distanciaH[inicio] = distanciaManh(inicio, fim);
        f[inicio] = custo[inicio] + distanciaH[inicio];

        List<int> open = new List<int>();//Lista Open
        List<int> closed = new List<int>();//Lista Closed


        //Inicio e o numero no vetor
        // i é o vertice participante daquele vetor na adjacencia

        LinkedList<Tuple<int, Node>> test = adjacencyList[inicio];

        while (adjacencyList[inicio] != adjacencyList[fim])
        {
            test = adjacencyList[inicio];
            foreach (Tuple<int, Node> i in test)
            {
                if (!open.Contains(i.Item1) && !closed.Contains(i.Item1))
                {
                    open.Add(i.Item1);
                    aux = custo[inicio] + i.Item2.getPeso();//Calculo do G
                    auxF = aux + distanciaManh(i.Item1, fim);

                    /*                        aux = custo[inicio] + i.Item2.getPeso();*/
                    if (auxF < f[i.Item1] || f[i.Item1] == -1)
                    {
                        custo[i.Item1] = custo[inicio] + i.Item2.getPeso();
                        f[i.Item1] = auxF;
                        caminho[i.Item1] = inicio;
                    }
                }
            }
            closed.Add(inicio);
            menorG = 500;

            foreach (int indice in open)
            {
                if (f[indice] < menorG)
                {
                    menorG = f[indice];
                    inicio = indice;
                }
            }
            open.Remove(inicio);

        }
        //Função de Criar o Caminho
        int cont;
        cont = fim;
        int valor1, valor2;
        String k;

        //adiciona o primeiro
        path.Add(fim);

        //Se o fim é 0 por enquanto é inutil
        //if (cont == 0)
        //{
        //    path.Add(caminho[cont]);
        //    cont = caminho[cont];
        //}

        //aux2 é o auxiliar do inicio
        while (cont != aux2)
        {
            path.Add(caminho[cont]);
            cont = caminho[cont];
        }

        int[] finalCaminho = new int[path.Count()];
        path.CopyTo(finalCaminho);

        for (int r = path.Count - 1; r > 0; r--)
        {
            valor1 = finalCaminho[r];
            valor2 = finalCaminho[r - 1];
            k = searchDirecao(valor1, valor2);
            caminhoSeguido.Add(valor1);
            tamanhoCaminho++;
            if (k == "Cima")
            {
                mudarTextoDirecao[valor1] = "SIGA EM FRENTE";
                Cima(marcador[valor1]);
            }
            if (k == "Baixo")
            {
                mudarTextoDirecao[valor1] = "VOLTE PARA TRAS";
                Baixo(marcador[valor1]);
            }
            if (k == "Esquerda")
            {
                mudarTextoDirecao[valor1] = "VIRE PARA ESQUERDA";
                Esquerda(marcador[valor1]);
            }
            if (k == "Direita")
            {
                mudarTextoDirecao[valor1] = "VIRE PARA DIREITA";
                Direita(marcador[valor1]);
            }

        }

    }


}

[RequireComponent(typeof(AudioSource))]
public class Aestrela : MonoBehaviour
{
    //Variaveis que podem ser mudados de acordo com o grafo.

    //ACABA AKI -------------------------------------------
    public GameObject[] marcador = new GameObject[35];
    public Text textoDirecao;
    AdjacencyList adjacencyList = new AdjacencyList(Tamanho);
    int auxiliarIndice;
    List<int> recursivoCaminho = new List<int>();




    //Parte da Musica
    public GameObject go;
    int contadorMusica = 0;
    int difIndice = 0;
    int musicaDestino = 0;
    int auxiliarFinal = 0;
    public AudioClip frente, baixo, esquerda, direita, chegouDestino;
    //Musica Acaba Aki




    //Imagem Acaba Aki

    // Start is called before the first frame update
    void Start()
    {
        auxiliarIndice = indiceImagem;
        textoDirecao.enabled = false;

        int inicio, fim, peso, auxiliar = 0, posX , posY;
        string direc,palavra;
        char[] aux;

        if (File.Exists(arquivoLoad))//Destino
        {
            string[] lines = File.ReadAllLines(arquivoLoad);
            Tamanho = Convert.ToInt32(lines[0]);
            //Tamanho = Convert.ToInt32(lines[0]);
            int[] auxiliar2 = new int[5];
            int cont = 0;
            // Read a text file line by line.  

            foreach (string line in lines)
            {
                cont = 0;
                int contElevador;
                palavra = "";
                aux = line.ToCharArray(0, line.Length);

                if (line.Equals("Destinos"))
                    break;
                if (auxiliar == 1)
                {
                    contElevador = 0;
                    if (aux[0].Equals('E'))//Verifica ao ler se na aresta tem um vértice elevador.
                        contElevador = 2;
                    for (int i = 0 + contElevador; i < line.Length; i++)
                    {
                        if (aux[i] == 44)
                        {
                            auxiliar2[cont] = Convert.ToInt32(palavra);
                            palavra = "";
                            cont++;
                        }
                        else
                            palavra += aux[i];
                    }

                    inicio = auxiliar2[0];
                    fim = auxiliar2[1];
                    peso = auxiliar2[2];
                    posX = auxiliar2[3];
                    posY = auxiliar2[4];

                    direc = palavra;

                    if(contElevador == 2)
                    {
                        if (condicaoMotora == 0)
                            peso += 0;
                        if (condicaoMotora == 1)
                            peso += 1;
                        if (condicaoMotora == 2)
                            peso += 2;
                        if (condicaoMotora == 3)
                            peso += 4;
                        if (condicaoMotora == 4)
                            peso += 8;
                    }
                    
                    adjacencyList.addEdgeAtEnd(inicio, fim, peso,posX,posY, direc);

                }
                if (auxiliar < 1)
                    auxiliar++;
            }
        }
        arquivoLoadCondicao = Application.persistentDataPath + "/condicao.txt";
        if (File.Exists(arquivoLoadCondicao))
        {
            string[] lines = File.ReadAllLines(arquivoLoadCondicao);
            condicaoMotora = Convert.ToInt32(lines[0]);
            Debug.Log(condicaoMotora);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Acha um caminho Diferente do primeiro ou e o primeiro.
        if (auxiliarIndice != indiceImagem && !recursivoCaminho.Contains(indiceImagem - 1) && indiceImagem <= Tamanho)
        {
            recursivoCaminho.Clear();//Limpa o ultimo caminho para poder ser criado o novo.

            textoDirecao.enabled = true;

            auxiliarIndice = indiceImagem;
            //Debug.Log(Tamanho);
            //Debug.Log(rota);
            //Debug.Log(indiceImagem);
            adjacencyList.aEstrela(indiceImagem - 1, rota, Tamanho, marcador, recursivoCaminho);
            if (indiceImagem - 1 != rota)
                adjacencyList.arrumaCaminho(marcador);

        }
        for (int i = 0; i < Tamanho; i++)
        {
            if (indiceImagem > Tamanho)
            {
                textoDirecao.text = "CUIDADO";
            }
            else if (i == indiceImagem)
            {
                if (mudarTextoDirecao[indiceImagem - 1].Equals("Falso"))
                    textoDirecao.text = "Caminho Invalido";
                else if (contadorMusica == 0)
                {
                    difIndice = indiceImagem;
                    contadorMusica = 1;

                    if (mudarTextoDirecao[indiceImagem - 1] == "SIGA EM FRENTE")
                        go.GetComponent<AudioSource>().clip = frente;
                    if (mudarTextoDirecao[indiceImagem - 1] == "VOLTE PARA TRAS")
                        go.GetComponent<AudioSource>().clip = baixo;
                    if (mudarTextoDirecao[indiceImagem - 1] == "VIRE PARA ESQUERDA")
                        go.GetComponent<AudioSource>().clip = esquerda;
                    if (mudarTextoDirecao[indiceImagem - 1] == "VIRE PARA DIREITA")
                        go.GetComponent<AudioSource>().clip = direita;

                    go.GetComponent<AudioSource>().Play();

                    textoDirecao.text = mudarTextoDirecao[indiceImagem - 1];

                }
                if (indiceImagem != difIndice)
                    contadorMusica = 0;
            }
            else if (rota == indiceImagem - 1 && musicaDestino == 0)
            {
                musicaDestino++;
                go.GetComponent<AudioSource>().clip = chegouDestino;//Terminou
                go.GetComponent<AudioSource>().Play();
                textoDirecao.text = "CHEGOU AO DESTINO";
            }
        }

        //if (indiceImagem != auxiliarFinal)
        //{
        //    auxiliarFinal = indiceImagem;
        //    Debug.Log(indiceImagem);
        //}
    }
}