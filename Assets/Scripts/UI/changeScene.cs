using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	void Start () {
		
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)){
			line.gameEnded = false;
			PlayerPrefs.SetInt("gameFrozen", 1);
			PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("nextLevel"));
			PlayerPrefs.SetInt("nextLevel", PlayerPrefs.GetInt("nextLevel")+1);
			SceneManager.LoadScene("Scenes/game-scene");
		}
	}
}
