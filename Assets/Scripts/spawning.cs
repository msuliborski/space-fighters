using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour {

    public bool gameEnded = false;



    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject enemy_2;

    public GameObject asteroid;

    [SerializeField]
    float vel = 5;

    bool firstIncrementOfRate = false;

    
    public int spawnEnemiesRate = 10;
    public int spawnAsteroidsRate = 15;
    int timerEnemies = 5;
    int timerAsteorids = 5;
    public GameObject lineObject;

    bool incrementOfRate = false;
    
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
        if(Input.anyKey) PlayerPrefs.SetInt("gameFrozen", 0);
        if(PlayerPrefs.GetInt("gameFrozen") == 0){
            if (lineObject.transform.position.x > 150 || lineObject.transform.position.x < 75)
            {
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
            else
            {
                timerAsteorids--;
                if (timerAsteorids == 0)
                {
                    timerAsteorids = spawnAsteroidsRate;
                    if (!line.gameEnded) SpawnAsteroids();
                }
            }
        }
	}
    void Spawn()
    {

        if (lineObject.transform.position.x > 250)
        {
            transform.position = new Vector3(12f, Random.Range(-3.5f, 3.5f), 0);
            go = Instantiate(enemy, transform.position, Quaternion.identity);
        }
        else if (lineObject.transform.position.x > 150)
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
        else
        {
            if (!incrementOfRate)
            {
                incrementOfRate = true;
                spawnEnemiesRate = 5;
            }
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

    void SpawnAsteroids()
    {
        transform.position = new Vector2(Random.Range(0f, 16f), 6f);
        go = Instantiate(asteroid, transform.position, Quaternion.identity);
    }
}