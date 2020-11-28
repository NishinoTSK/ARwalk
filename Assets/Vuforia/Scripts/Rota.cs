using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
public static class Extension
{
    public static void clear(this InputField inputfield)
    {
        inputfield.Select();
        inputfield.text = "";
    }
}
public class Rota : MonoBehaviour
{

    static public int Tamanho = 0;
    static public int rota = 0; //Destino
    static public int indiceImagem = -1; // Vertice Atual
    static public string[] mudarTextoDirecao;
    static public string arquivoLoad;
    static public string arquivoLoadCondicao;
    static public int condicaoMotora = -1;

}
