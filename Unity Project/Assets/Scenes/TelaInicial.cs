using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public Button iniciar, grafo, instrucao;
    public string nomeCenaIniciar = "Menu", nomeCenaGrafo = "Grafo", nomeCenaInstrucao = "RInstruct";

    // Start is called before the first frame update
    void Start()
    {
        instrucao.onClick = new Button.ButtonClickedEvent();
        instrucao.onClick.AddListener(instrucaoTrocar);
        iniciar.onClick = new Button.ButtonClickedEvent();
        iniciar.onClick.AddListener(inicio);
        grafo.onClick = new Button.ButtonClickedEvent();
        grafo.onClick.AddListener(inserirGrafo);
    }

    public void inicio()
    {
        SceneManager.LoadScene(nomeCenaIniciar);
    }

    public void inserirGrafo()
    {
        SceneManager.LoadScene(nomeCenaGrafo);
    }
    
    public void instrucaoTrocar()
    {
        SceneManager.LoadScene(nomeCenaInstrucao);
    }

}
