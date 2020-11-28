using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using static Rota;

public class TerceiraTela : MonoBehaviour
{

    public Button ok, destinos;
    public InputField inicio,fim,peso,direc,escada,posX, posY;
    public GameObject atual, proximo;
    // Start is called before the first frame update
    void Start()
    {
        ok.onClick.AddListener(adicionar);
        destinos.onClick.AddListener(proximaTela);
    }
   
    public void adicionar()
    {
        using (StreamWriter sw = File.AppendText(Application.persistentDataPath + "/temporario.txt"))
        {

           
            if (escada.text.Equals("S"))
            {
                sw.WriteLine(inicio.text + "," + fim.text + "," + peso.text + "," + posX.text + "," + posY.text + "," + direc.text + "," + "Elevador");
                //int aux;
                //aux = Convert.ToInt32(peso.text);
                //aux = aux - 3;
                //peso.text = Convert.ToString(aux);
            }
            sw.WriteLine(inicio.text + "," + fim.text + "," + peso.text + "," + posX.text + "," + posY.text + "," + direc.text);
        }
        inicio.clear();
        fim.clear();
        peso.clear();
        direc.clear();
        posX.clear();
        posY.clear();
    }

    public void proximaTela()
    {
        using (StreamWriter sw = File.AppendText(Application.persistentDataPath + "/temporario.txt"))
        {
            sw.WriteLine("Destinos");
        }
        atual.SetActive(false);
        proximo.SetActive(true);
    }

}
