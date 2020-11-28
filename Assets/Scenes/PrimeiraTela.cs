using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using static Rota;
using UnityEngine.SceneManagement;

public class PrimeiraTela : MonoBehaviour
{
    // Start is called before the first frame update
    public Button novo,carregar;
    public GameObject primeiro, segundo;
    public InputField nomeArquivo;

    private void Start()
    {
        novo.onClick.AddListener(gerar);
        carregar.onClick.AddListener(carregarLoad);
    }

    public void gerar()
    {
        primeiro.SetActive(false);
        segundo.SetActive(true);
    }

    public void carregarLoad()
    {
        arquivoLoad = Application.persistentDataPath + "/" + nomeArquivo.text + ".txt";
        string trocarCenario = File.ReadAllText(arquivoLoad);
        File.WriteAllText(Application.persistentDataPath + "/save.txt", trocarCenario);
        SceneManager.LoadScene("TelaInicial");
    }

}
