using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public IntVariable LevelCountVariable;
    
    [SerializeField]
    float vel = -5f;

    [SerializeField]
    GameObject player_1;

    [SerializeField]
    GameObject player_2;

    public AudioClip gameOver;

    public GameObject player_1Wins_sprite;
    public GameObject player_2Wins_sprite;
    public GameObject noOneWins_sprite;

    public static bool gameEnded = false;

    private AudioSource source;

    //bool gameEnded = spawner.gameEnded;

    // Use this for initialization

    void Start()
    {
        source = GetComponent<AudioSource>();
        player_1 = GameObject.Find("player_1");
        player_2 = GameObject.Find("player_2");

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(vel, 0, 0);
        player_1Wins_sprite.SetActive(false);
        player_2Wins_sprite.SetActive(false);
        noOneWins_sprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.anyKey) PlayerPrefs.SetInt("gameFrozen", 0);
        if(PlayerPrefs.GetInt("gameFrozen") == 0){
            //Debug.Log("currentLevel: " + PlayerPrefs.GetInt("currentLevel") + ", currentPlayer1Points: " + PlayerPrefs.GetInt("currentPlayer1Points") + ", currentPlayer2Points: " + PlayerPrefs.GetInt("currentPlayer2Points"));
            if (!gameEnded){
                if (!player_1.active && !player_2.active) {noOne_Wins(); handleGameEnd ();}
                else if (player_1.transform.position.x >= transform.position.x) {Player_1Wins(); handleGameEnd ();}
                else if (player_2.transform.position.x >= transform.position.x) {Player_2Wins(); handleGameEnd ();}
            }
        }
    }

    void noOne_Wins(){
        source.PlayOneShot(source.clip, 1f);
        noOneWins_sprite.SetActive(true);
    }
    void Player_1Wins(){
        player_1Wins_sprite.SetActive(true);
		PlayerPrefs.SetInt("currentPlayer1Points", PlayerPrefs.GetInt("currentPlayer1Points")+1);
        //PlayerPrefs.SetInt("currentLevel",  PlayerPrefs.GetInt("currentLevel")+1);
    }
    void Player_2Wins(){
        player_2Wins_sprite.SetActive(true);
		PlayerPrefs.SetInt("currentPlayer2Points", PlayerPrefs.GetInt("currentPlayer2Points")+1);
        //PlayerPrefs.SetInt("currentLevel",  PlayerPrefs.GetInt("currentLevel")+1);
    }

    void handleGameEnd (){
        gameEnded = true;
    }

    void ultimateGameOver (){
        gameEnded = true;
		PlayerPrefs.SetInt("currentPlayer1Points", 0);
		PlayerPrefs.SetInt("currentPlayer2Points", 0);
        PlayerPrefs.SetInt("currentLevel", 1);
        PlayerPrefs.SetInt("gameFrozen", 1);
    }

}
