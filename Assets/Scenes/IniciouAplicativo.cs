using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using static Rota;
using UnityEngine.UI;

public class IniciouAplicativo : MonoBehaviour
{
    public GameObject atual, lista;


    private void Start()
    {
        Debug.Log("1 vez");
        string arquivoVazio = (Application.persistentDataPath + "/save.txt");
        Debug.Log(arquivoVazio);
        if (!File.Exists(arquivoVazio))
        {
            atual.SetActive(true);
        }
        else
        {
            atual.SetActive(false);
            lista.SetActive(true);
        }

        arquivoLoadCondicao = Application.persistentDataPath + "/condicao.txt";
        if (!File.Exists(arquivoLoadCondicao))
        {
            File.WriteAllText(arquivoLoadCondicao, "-1");
        }
        //if (arquivoVazio.Length == 0)
        //{
        //    atual.SetActive(true);
        //}
    }
    private void Update()
    {
        
    }
}
