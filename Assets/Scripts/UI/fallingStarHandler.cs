using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingStarHandler : MonoBehaviour {

	Rigidbody2D _rd;

	
	// Update is called once per frame
	void Start () {
		_rd = GetComponent<Rigidbody2D>();
		//_rd.transform.position = new Vector3(-15, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {

		_rd.velocity = new Vector3 (-4.2f, -3, 0);
		if (_rd.transform.position.y <= -25) _rd.transform.position = new Vector3(15, 10, 0);

	}
}
