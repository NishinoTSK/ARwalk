using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rota;

public class Marcador1 : MonoBehaviour
{

    void Start() {
        if(rota == 1){
            Debug.Log("Ta funcionando");
		}
    }

    void Update(){
            if(rota == 1){
               var rotationVector = transform.rotation.eulerAngles;
               rotationVector.y = 270;
               transform.rotation = Quaternion.Euler(rotationVector);
		}
            if(rota == 2){
               Debug.Log("Ta funcionando 2");
               var rotationVector = transform.rotation.eulerAngles;
               rotationVector.y = 0;
               transform.rotation = Quaternion.Euler(rotationVector);
		}

	}

    void Esquerda()
    {
        transform.Rotate(new Vector3(0,180,0));
	}

    void Direita()
    {
        transform.Rotate(new Vector3(0,0,0));
	}

    void Cima()
    {
        transform.Rotate(new Vector3(0,270,0));
	}

    void Baixo()
    {
        transform.Rotate(new Vector3(0,90,0));
	}
}
