
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handleBack : MonoBehaviour {

	void OnMouseDown()
    {
		SceneManager.LoadScene("Scenes/menu-scene");
    }

}	