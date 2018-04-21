using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_1 : MonoBehaviour {

    [SerializeField]
    float hp = 5f;
    [SerializeField]
    float vel = 5f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject instPoint_1;

    GameObject go;
    private Rigidbody2D _rb;
    // Use this for initialization
    void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) _rb.velocity = new Vector3(_rb.velocity.x, vel, 0);
        if (Input.GetKeyUp(KeyCode.W)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);

        if (Input.GetKey(KeyCode.S)) _rb.velocity = new Vector3(_rb.velocity.x, -vel, 0);
        if (Input.GetKeyUp(KeyCode.S)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);

        if (Input.GetKey(KeyCode.A)) _rb.velocity = new Vector3(-vel, _rb.velocity.y, 0);
        if (Input.GetKeyUp(KeyCode.A)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.D)) _rb.velocity = new Vector3(vel, _rb.velocity.y, 0);
        if (Input.GetKeyUp(KeyCode.D)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.T))
        {
            go = Instantiate(bullet, instPoint_1.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = vel * Vector2.right;
            Destroy(go, 3f);
        }
    }
}
