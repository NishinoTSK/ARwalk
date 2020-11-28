using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using static Rota;

public class ListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;


    private List<GameObject> buttons;
    //static readonly string textFile = @"C:\Users\oniyo\Desktop\casa.txt";
    static char[] aux;
    static string palavra;
    public int auxiliar = 0;
    public int indice;
    public string destino;

    void Start()
    {
        buttons = new List<GameObject>();
        //Destroi os botoes para nao ficar criando botao em cima de botao
        if(buttons.Count >= 0)
        {
            foreach(GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
        }
        //Crio os botoes aki, preciso ler o arquivo aki dos destinos

        if (!File.Exists(arquivoLoad))
        {
            arquivoLoad = Application.persistentDataPath + "/save.txt";
        }
        // Read a text file line by line.  
        string[] lines = File.ReadAllLines(arquivoLoad);
        foreach (string line in lines)
        {
            palavra = "";
            aux = line.ToCharArray(0, line.Length);
            if (auxiliar == 1)
                for (int i = 0; i < line.Length; i++)
                {
                    if (aux[i] == 44)
                    {
                        destino = palavra;
                        palavra = "";
                    }
                    else
                        palavra += aux[i];
                }
            if (line.Equals("Destinos"))
            {
                auxiliar = 1;
            }
            if (palavra.Length > 0)
            {
                indice = Convert.ToInt32(palavra);
                CriarButton(destino, indice);
            }
        }
    }

    public void CriarButton(string nome, int id)
    {

        GameObject button = Instantiate(buttonTemplate) as GameObject;
        button.SetActive(true);

        button.GetComponent<ButtonList>().SetText(nome, id);

        button.transform.SetParent(buttonTemplate.transform.parent, false);
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }
}
