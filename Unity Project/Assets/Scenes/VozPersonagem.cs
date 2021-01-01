using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static Rota;
using System.IO;
using UnityEngine.SceneManagement;

public class VozPersonagem : MonoBehaviour
{
    public Toggle enableVoz;

    private void Start()
    {
        arquivoLoadVoz = Application.persistentDataPath + "/voz.txt";
        if (File.Exists(arquivoLoadVoz))
        {
            string[] lines = File.ReadAllLines(arquivoLoadVoz);
            permitirVozPersonagem = Convert.ToInt32(lines[0]);
        }
        else
            File.WriteAllText(arquivoLoadVoz, Convert.ToString("0"));


        if (permitirVozPersonagem == 0)
            enableVoz.isOn = false;
        else
        {
            enableVoz.isOn = true;
            permitirVozPersonagem = 1;
            arquivoLoadVoz = Application.persistentDataPath + "/voz.txt";
            File.WriteAllText(arquivoLoadVoz, Convert.ToString(permitirVozPersonagem));
            //Debug.Log("Depois");
            //Debug.Log(permitirVozPersonagem);
        }
    }

    public void Toggle_Changed()
    {
        if (permitirVozPersonagem == 0)
            permitirVozPersonagem = 1;
        else
            permitirVozPersonagem = 0;

        arquivoLoadVoz = Application.persistentDataPath + "/voz.txt";
        File.WriteAllText(arquivoLoadVoz, Convert.ToString(permitirVozPersonagem));

        //Debug.Log(permitirVozPersonagem);
    }


}
