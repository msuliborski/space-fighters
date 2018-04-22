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

    public static float distanceToFinish = 0;

    //bool gameEnded = spawner.gameEnded;

    // Use this for initialization

    void Start()
    {
        source = GetComponent<AudioSource>();
        player_1 = GameObject.Find("player_1");
        player_2 = GameObject.Find("player_2");

        
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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(vel, 0, 0);

            if (player_1 && player_2)
            {
                float _dist1 = transform.position.x - player_1.transform.position.x;
                float _dist2 = transform.position.x - player_2.transform.position.x;
                if (_dist1 <= _dist2) distanceToFinish = transform.position.x - player_1.transform.position.x;
                else distanceToFinish = transform.position.x - player_2.transform.position.x;
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
        PlayerPrefs.SetInt("gameFrozen", 1);
    }

}
