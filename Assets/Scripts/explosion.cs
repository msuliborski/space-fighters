using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {


    private float _explosionTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _explosionTimer += Time.deltaTime;
        if (_explosionTimer >= 0.8) Destroy(gameObject);
	}
}
