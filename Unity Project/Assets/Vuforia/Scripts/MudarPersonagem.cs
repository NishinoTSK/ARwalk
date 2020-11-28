using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Rota;

public class MudarPersonagem : MonoBehaviour
{

    public Texture imagemInicial,destino, surpresa;

    // Update is called once per frame
    void Update()
    {
            
            if (rota == indiceImagem-1)
                this.gameObject.GetComponent<RawImage>().texture = destino;
            else if(indiceImagem > Tamanho)
                this.gameObject.GetComponent<RawImage>().texture = surpresa;
            else
                this.gameObject.GetComponent<RawImage>().texture = imagemInicial;
    }
}
