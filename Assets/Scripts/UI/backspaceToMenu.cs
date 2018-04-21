using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backspaceToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}	
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Backspace)){
			SceneManager.LoadScene("Scenes/menu-scene");
			line.gameEnded = false;
		}
	}
}