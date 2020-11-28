using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Rota;

public class Engrenagem : MonoBehaviour
{
    public RawImage imagem;
    string nomeCenaTelaInicial = "TelaInicial";

    public void changeScene()
    {
        SceneManager.LoadScene(nomeCenaTelaInicial);
    }
}
