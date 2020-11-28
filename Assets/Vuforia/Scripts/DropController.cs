using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;
using static Rota;

public class DropController : MonoBehaviour
{
    public Dropdown condicao;
    public void setarCondicao()
    {
        Debug.Log(condicao.value);
        condicaoMotora = condicao.value;
        arquivoLoadCondicao = Application.persistentDataPath + "/condicao.txt";
        File.WriteAllText(arquivoLoadCondicao, Convert.ToString(condicaoMotora));
    }

    private void Start()
    {
        arquivoLoadCondicao = Application.persistentDataPath + "/condicao.txt";
        if (File.Exists(arquivoLoadCondicao))
        {
            string[] lines = File.ReadAllLines(arquivoLoadCondicao);
            condicaoMotora = Convert.ToInt32(lines[0]);
        }
        if (condicaoMotora == -1)
            File.WriteAllText(arquivoLoadCondicao, Convert.ToString("0"));
    }
}
