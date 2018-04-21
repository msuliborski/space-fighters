using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_1 : MonoBehaviour {


    [SerializeField]
    float vel = 5f;
	private Rigidbody2D _rb;
	
	
	void Start () {
		_rb = gameObject.GetComponent<Rigidbody2D>();
		_rb.gravityScale = 0f;
	}
	
	
	void Update () {

		if (Input.GetKey(KeyCode.W)) _rb.velocity = new Vector3(_rb.velocity.x, vel, 0);
		if (Input.GetKeyUp(KeyCode.W)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.S)) _rb.velocity = new Vector3(_rb.velocity.x, -vel, 0);
		if (Input.GetKeyUp(KeyCode.S)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
		
		if (Input.GetKey(KeyCode.A)) _rb.velocity = new Vector3(-vel, _rb.velocity.y, 0);
		if (Input.GetKeyUp(KeyCode.A)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
		
		if (Input.GetKey(KeyCode.D)) _rb.velocity = new Vector3(vel, _rb.velocity.y, 0);
		if (Input.GetKeyUp(KeyCode.D)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
		
		
	}
}
