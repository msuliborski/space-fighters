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
			line.gameEnded = false;
			PlayerPrefs.SetInt("gameFrozen", 1);
			SceneManager.LoadScene("Scenes/menu-scene");
		}
	}
}