
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleStart : MonoBehaviour {

	void OnMouseDown()
    {
		SceneManager.LoadScene("Scenes/game-scene");
    }

}	