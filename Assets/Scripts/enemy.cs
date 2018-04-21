using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject explosion;
    public GameObject bullet;
    public float hp = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "bullet")
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
