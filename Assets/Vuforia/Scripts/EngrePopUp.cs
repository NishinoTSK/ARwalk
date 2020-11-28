using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using static Rota;

public class EngrePopUp : MonoBehaviour
{
    public GameObject atual;
    public Button ok;
    public InputField senha;
    private string senhaCerta = "123456";
    string nomeCenaTelaInicial = "TelaInicial";

    void Start()
    {
        ok.onClick.AddListener(clickSenha);
    }
    public void clickSenha()
    {
        atual.SetActive(false);
        
        if(senha.text == senhaCerta)
        {
            SceneManager.LoadScene(nomeCenaTelaInicial);
        }
        senha.clear();
    }
}
