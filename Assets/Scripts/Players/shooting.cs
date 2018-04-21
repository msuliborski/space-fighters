using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject instPoint_1;

    [SerializeField]
    GameObject instPoint_2;

    [SerializeField]
    float velocity = 5f;

    GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            go = Instantiate(bullet, instPoint_1.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = velocity * Vector2.left;
            Destroy(go, 3f);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            go = Instantiate(bullet, instPoint_1.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = velocity * Vector2.right;
            Destroy(go, 3f);
        }
        if(Input.GetKeyDown(KeyCode.Comma))
        {
            go = Instantiate(bullet, instPoint_2.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = velocity * Vector2.left;
            Destroy(go, 3f);
        }
        if(Input.GetKeyDown(KeyCode.Period))
        {
            go = Instantiate(bullet, instPoint_2.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = velocity * Vector2.right;
            Destroy(go, 3f);
        }
    }
}
