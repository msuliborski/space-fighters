using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterToPlayAgain : MonoBehaviour {

	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Return)){
			PlayerPrefs.SetInt("gameFrozen", 1);
			line.gameEnded = false;
			SceneManager.LoadScene("Scenes/game-scene");
			
		}
	}
}