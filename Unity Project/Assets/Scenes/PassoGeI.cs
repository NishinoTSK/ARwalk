using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static Rota;
using UnityEngine.UI;

public class PassoGeI : MonoBehaviour
{
    public Button proximo, voltar;
    public GameObject anteriorPainel, proximoPainel, atualPainel;
    string nomeCenaTelaInicial = "TelaInicial";
    // Start is called before the first frame update
    void Start()
    {
        voltar.onClick.AddListener(anteriorTela);
        proximo.onClick.AddListener(proximaTela);
    }

    public void anteriorTela()
    {
        atualPainel.SetActive(false);
        anteriorPainel.SetActive(true);
    }

    public void proximaTela()
    {
        atualPainel.SetActive(false);
        proximoPainel.SetActive(true);
    }

    private void Update()
    {
        Debug.Log(condicaoMotora);
    }
}
