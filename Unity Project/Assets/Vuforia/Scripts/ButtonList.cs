using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using static Rota;

public class ButtonList : MonoBehaviour
{
    [SerializeField]
    public Text myText;
    private string myTextString;
    [SerializeField]
    private ListControl buttonControl;

    public int idDestino;
    public string nomeCenaJogo = "Principal";
    
    private void Start()
    {
        if (File.Exists(arquivoLoad))//Destino
        {

            string[] lines = File.ReadAllLines(arquivoLoad);
            if (Convert.ToInt32(lines[0]) != Tamanho)
            {
                Tamanho = Convert.ToInt32(lines[0]);
                Debug.Log(Tamanho);
            }
            mudarTextoDirecao = new string[Tamanho];
            for (int i = 0; i < Tamanho; i++)
                mudarTextoDirecao[i] = "Falso";
        }
    }
    public void SetText(string textString,int id)
    {
        myTextString = textString;
        myText.text = textString;
        idDestino = id;
        this.gameObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick); //Pra OnClick funcionar
    }

    public void OnClick()
    {
        rota = idDestino;
        SceneManager.LoadScene(nomeCenaJogo);
    }
}
