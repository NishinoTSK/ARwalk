using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using static Rota;
using UnityEngine.SceneManagement;


public class QuartaTela : MonoBehaviour
{
    public InputField nome, indice,nomeArquivo;
    public Button ok,salvar;
    string nomeCenaTelaInicial = "TelaInicial";
    
    // Start is called before the first frame update
    void Start()
    {
        ok.onClick.AddListener(adicionar);
        salvar.onClick = new Button.ButtonClickedEvent();
        salvar.onClick.AddListener(proximaTela);
    }

    public void adicionar()
    {
        using (StreamWriter sw = File.AppendText(Application.persistentDataPath + "/temporario.txt"))
        {
            //if(escada.text.Equals("Sim"))
            //{
            //}
            sw.WriteLine(nome.text + "," + indice.text);

        }
        nome.clear();
        indice.clear();

    }

    public void proximaTela()
    {
        string teste = File.ReadAllText(Application.persistentDataPath + "/temporario.txt");
        File.WriteAllText(Application.persistentDataPath + "/save.txt",teste);
        File.WriteAllText(Application.persistentDataPath + "/" + nomeArquivo.text + ".txt", teste);
        arquivoLoad = Application.persistentDataPath + "/save.txt";

        SceneManager.LoadScene(nomeCenaTelaInicial);
    }

}
