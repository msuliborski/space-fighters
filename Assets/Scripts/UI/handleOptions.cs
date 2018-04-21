using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleOptions : MonoBehaviour {
	void OnMouseDown()
    {
		SceneManager.LoadScene("Scenes/options-scene");
    }
}	