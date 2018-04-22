using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultHandler : MonoBehaviour {

	int a,b;
	// Use this for initialization
	void Start () {

		a = Random.Range(0, 2);
		b = Random.Range(0, 2);
		while(b == a) b = Random.Range(0, 2);

		PlayerPrefs.SetInt("currentLevel", 1);
		PlayerPrefs.SetInt("nextLevel", 2);
		PlayerPrefs.SetInt("currentPlayer1Points", 0);
		PlayerPrefs.SetInt("currentPlayer2Points", 0);
		PlayerPrefs.SetInt("gameFrozen", 1);
		PlayerPrefs.SetInt("player1skin", a);
		PlayerPrefs.SetInt("player2skin", b);

	}

	
	
	// Update is called once per frame
	void Update () {
		

		//Debug.Log("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + ", currentPlayer1Points: " + PlayerPrefs.GetInt("currentPlayer1Points") + ", currentPlayer2Points: " + PlayerPrefs.GetInt("currentPlayer2Points"));
		
	}
}
