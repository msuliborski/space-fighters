using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour {

    [SerializeField]
    float scrollSpeed = 0.5f;

	
    public Text levelInfo;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (line.distanceToFinish >= 0) levelInfo.text = " FINISH IN: " + (int) line.distanceToFinish + "m";
		else levelInfo.text = "  ";
		if(Input.anyKey) PlayerPrefs.SetInt("gameFrozen", 0);
        if(PlayerPrefs.GetInt("gameFrozen") == 0){
			Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
			GetComponent<Renderer>().material.mainTextureOffset = offset;
		}
	}
}
