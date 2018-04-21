using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2 : MonoBehaviour {

    [SerializeField]
    float hp = 5f;
        
    [SerializeField]
    float vel = 5f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject instPoint_2;

    GameObject go;
    private Rigidbody2D _rb;
    // Use this for initialization
    void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) _rb.velocity = new Vector3(_rb.velocity.x, vel, 0);
        if (Input.GetKeyUp(KeyCode.UpArrow)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);

        if (Input.GetKey(KeyCode.DownArrow)) _rb.velocity = new Vector3(_rb.velocity.x, -vel, 0);
        if (Input.GetKeyUp(KeyCode.DownArrow)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow)) _rb.velocity = new Vector3(-vel, _rb.velocity.y, 0);
        if (Input.GetKeyUp(KeyCode.LeftArrow)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.RightArrow)) _rb.velocity = new Vector3(vel, _rb.velocity.y, 0);
        if (Input.GetKeyUp(KeyCode.RightArrow)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            go = Instantiate(bullet, instPoint_2.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = vel * Vector2.left;
            Destroy(go, 3f);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            go = Instantiate(bullet, instPoint_2.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = vel * Vector2.right;
            Destroy(go, 3f);
        }
    }
}
