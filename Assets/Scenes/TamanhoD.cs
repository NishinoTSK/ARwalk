using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using static Rota;

public class TamanhoD : MonoBehaviour
{
    // Start is called before the first frame update
    public Button buttonClick;
    public InputField input;
    public GameObject panel,panel2;

    private void Start()
    {
        buttonClick.onClick.AddListener(clicou);
    }

    public void clicou()
    {
        Tamanho = Convert.ToInt32(input.text);//Define o Tamanho do grafo
        File.WriteAllText(Application.persistentDataPath + "/temporario.txt", input.text + "\n");


        panel.SetActive(false);
        panel2.SetActive(true);
    }
}
