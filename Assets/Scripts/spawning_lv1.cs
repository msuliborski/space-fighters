using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning_lv1 : MonoBehaviour {

    public bool gameEnded = false;


    [SerializeField]
    GameObject enemy;

    [SerializeField]
    float vel = 5;

    
    public int spawnEnemiesRate = 30;
    int timerEnemies = 5;
    public GameObject lineObject;

    int x;

    public AudioClip music;

    private AudioSource source;

    GameObject go;

	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
        source.Play();
        lineObject = GameObject.Find("line");
	}
	
	
	void FixedUpdate () {
	
		if (timerEnemies != 0)
		{
			timerEnemies--;
		}
		else
		{
			if (!line.gameEnded) Spawn();
			timerEnemies = spawnEnemiesRate;
		} 
	}
    void Spawn()
    {

       
		transform.position = new Vector3(12f, Random.Range(-3.5f, 3.5f), 0);
		go = Instantiate(enemy, transform.position, Quaternion.identity);
        
    	Destroy(go, 5f);
        
    }

}
