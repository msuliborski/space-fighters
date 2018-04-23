using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleControls : MonoBehaviour {
	void OnMouseDown()
    {
		SceneManager.LoadScene("Scenes/controls-scene");
    }
}	