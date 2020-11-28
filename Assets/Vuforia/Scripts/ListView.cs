using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListView : MonoBehaviour {

	[SerializeField] Transform ButtonListContent;
	[SerializeField] GameObject buttonPrefab;

	// Use this for initialization
	void Start () {

			GameObject button = (GameObject)Instantiate (buttonPrefab);
			button.GetComponentInChildren<Text>().text = "Hello";			
			button.transform.parent = ButtonListContent;

	}

}
