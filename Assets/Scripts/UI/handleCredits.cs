
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleCredits : MonoBehaviour {
	void OnMouseDown()
    {
		SceneManager.LoadScene("Scenes/credits-scene");
    }
}	