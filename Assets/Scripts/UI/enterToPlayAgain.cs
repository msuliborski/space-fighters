﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterToPlayAgain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			line.gameEnded = false;
		}
	}
}
