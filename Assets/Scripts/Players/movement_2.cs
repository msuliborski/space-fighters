using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_2 : MonoBehaviour {

	private Rigidbody2D _rb;
	
	
	void Start () {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		_rb.gravityScale = 0f;
	}
	
	
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow )) _rb.velocity = new Vector3(_rb.velocity.x, 1, 0);
		if (Input.GetKeyUp(KeyCode.UpArrow)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.DownArrow)) _rb.velocity = new Vector3(_rb.velocity.x, -1, 0);
		if (Input.GetKeyUp(KeyCode.DownArrow)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.LeftArrow)) _rb.velocity = new Vector3(-1, _rb.velocity.y, 0);
		if (Input.GetKeyUp(KeyCode.LeftArrow)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
		
		if (Input.GetKey(KeyCode.RightArrow)) _rb.velocity = new Vector3(1, _rb.velocity.y, 0);
		if (Input.GetKeyUp(KeyCode.RightArrow)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
		
		
	}
}
