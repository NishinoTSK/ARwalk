using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rota;

public class AlgoritmoDeRota : MonoBehaviour
{
    public GameObject []marcador = new GameObject[10];

    void Start() {
        if(rota == 1){
            Cima(marcador[0]);
            Cima(marcador[1]);
            Cima(marcador[2]);
            Cima(marcador[3]);
            Debug.Log("Ta funcionando");
		}
    }

    void Update(){
/*            Cima(m1);
            Esquerda(m2);
            Baixo(m3);
            Esquerda(m4);
            Direita(m5);
            Baixo(m6);
            Direita(m7);
            Baixo(m8);
            Baixo(m9);
            Baixo(m10);*/
	}

    void Esquerda(GameObject x)
    {
               var rotationVector = x.transform.rotation.eulerAngles;
               rotationVector.y = 180;
               x.transform.rotation = Quaternion.Euler(rotationVector);
	}

    void Direita(GameObject x)
    {
               var rotationVector = x.transform.rotation.eulerAngles;
               rotationVector.y = 0;
               x.transform.rotation = Quaternion.Euler(rotationVector);
	}

    void Cima(GameObject x)
    {
               var rotationVector = x.transform.rotation.eulerAngles;
               rotationVector.y = 270;
               x.transform.rotation = Quaternion.Euler(rotationVector);
	}

    void Baixo(GameObject x)
    {
               var rotationVector = x.transform.rotation.eulerAngles;
               rotationVector.y = 90;
               x.transform.rotation = Quaternion.Euler(rotationVector);
	}
}
