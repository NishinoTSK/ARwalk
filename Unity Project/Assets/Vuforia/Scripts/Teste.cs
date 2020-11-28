using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using static Rota;

public class Teste : MonoBehaviour {

 public Button Piscina,CampoDeFutebol;
 public string nomeCenaJogo = "Principal";
 private string nomeDaCena;


 void Start () {

  nomeDaCena = SceneManager.GetActiveScene ().name;
  Cursor.visible = true;
  Time.timeScale = 1;


  // =========SETAR BOTOES==========//
  Piscina.onClick = new Button.ButtonClickedEvent();
  Piscina.onClick.AddListener(() => Jogar());

  CampoDeFutebol.onClick = new Button.ButtonClickedEvent();
  CampoDeFutebol.onClick.AddListener(() => Jogar1());

 }

 //===========VOIDS NORMAIS=========//
 void Update(){

 }

 private void Jogar(){
 rota = 9;
 SceneManager.LoadScene (nomeCenaJogo);
 }

 private void Jogar1(){
 rota = 6;
 SceneManager.LoadScene (nomeCenaJogo);
 }

 private void Sair(){
  Application.Quit ();
 }
}