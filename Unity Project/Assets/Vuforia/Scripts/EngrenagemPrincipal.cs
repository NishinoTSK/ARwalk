using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Rota;

public class EngrenagemPrincipal : MonoBehaviour
{
    public RawImage imagem;
    public GameObject popUp;

    public void changeScene()
    {
        popUp.SetActive(true);
    }
}
