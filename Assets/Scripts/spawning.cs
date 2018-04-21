using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour {

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject enemy_2;

    [SerializeField]
    float vel = 5;

    [SerializeField]
    int spawnRate = 30;

    enum enemies
    {
        enemy,
        enemy_2
    }

    int x;
    int t = 5;
    GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void FixedUpdate () {
        if(t!=0)
        {
            t--;
        }
        if (t==0)
        {
            Spawn();
            t = spawnRate;
        }
	}
    void Spawn()
    {
        x = Random.Range(0, 50);
        transform.position = new Vector3(12f, Random.Range(-3.5f, 3.5f), 0);
        if (x % 2 == 0)
        {
            go = Instantiate(enemy, transform.position, Quaternion.identity);
        }
        if (x % 2 == 1)
        {
            go = Instantiate(enemy_2, transform.position, Quaternion.identity);
        }
        go.GetComponent<Rigidbody2D>().velocity = new Vector3(-vel, 0, 0);
        Destroy(go, 5f);
    }
}
