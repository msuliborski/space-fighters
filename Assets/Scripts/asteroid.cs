using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {



    private Rigidbody2D _rb;
    private AudioSource source;
    public AudioClip jeb;
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "bullet")
        {
            source.PlayOneShot(source.clip);
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            
        }
        else if (collision.gameObject.transform.tag == "enemy")
        {
            source.PlayOneShot(source.clip);
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);

        }
    }



    // Use this for initialization
    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        _rb.velocity = new Vector2(-10f, -5f);
	}
}
