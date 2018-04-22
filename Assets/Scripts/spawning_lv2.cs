using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning_lv2 : MonoBehaviour {

    public bool gameEnded = false;



    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject enemy_2;

    [SerializeField]
    float vel = 5;

    
    public int spawnEnemiesRate = 30;
    int timerEnemies = 5;
    public GameObject lineObject;

    
    
    enum enemies
    {
        enemy,
        enemy_2
    }

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

		x = Random.Range(0, 2);
		transform.position = new Vector3(12f, Random.Range(-3.5f, 3.5f), 0);
		if (x == 0)
		{
			go = Instantiate(enemy, transform.position, Quaternion.identity);
		}
		else if (x == 1)
		{
			go = Instantiate(enemy_2, transform.position, Quaternion.identity);
		}
		Destroy(go, 5f);
	}
    
}
