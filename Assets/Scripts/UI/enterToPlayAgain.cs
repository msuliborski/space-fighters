using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterToPlayAgain : MonoBehaviour {

	





	public enum Combinations
    {
        TractorGekko,
        CycleGekko,
        BoatGekko,
        CycleHussar,
        TractorHussar,
        BoatHussar,
        CycleFisherman,
        TractorFisherman,
        BoatFisherman
    };

    List<string> Hero;

    List<string> Vehicle;

    private List<Combinations> Draws;
    int index;
    string temp1;
    string temp2;
    Combinations x;
    Combinations Player1, Player2;
	// Use this for initialization


	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Return)){
			PlayerPrefs.SetInt("gameFrozen", 1);
			line.gameEnded = false;
			PlayerPrefs.SetInt("gameFrozen", 0);
			drawChamp();
			SceneManager.LoadScene("Scenes/game-scene");
		}
		
	}

    public void drawChamp(){

        Vehicle = new List<string> { "Tractor", "Cycle", "Boat"};
        Hero = new List<string> {"Gekko", "Hussar", "Fisherman"};
        
        index = Random.Range(0, 3);
        temp1 = Vehicle[index];
        Vehicle.RemoveAt(index);
        index = Random.Range(0, 3);
        temp2 = Hero[index];
        Hero.RemoveAt(index); 

        Player1 = (Combinations)System.Enum.Parse(typeof(Combinations) , temp1 + temp2);

        Debug.Log(temp1 + temp2);

        index = Random.Range(0, 2);
        temp1 = Vehicle[index];
        Vehicle.RemoveAt(index);
        index = Random.Range(0, 2);
        temp2 = Hero[index];
        Hero.RemoveAt(index);

        Player2 = (Combinations)System.Enum.Parse(typeof(Combinations), temp1 + temp2);

        Debug.Log(temp1 + temp2);

        PlayerPrefs.SetInt("currentLevel", 1);
		PlayerPrefs.SetInt("nextLevel", 2);
		PlayerPrefs.SetInt("currentPlayer1Points", 0);
		PlayerPrefs.SetInt("currentPlayer2Points", 0);
		PlayerPrefs.SetInt("gameFrozen", 1);
		PlayerPrefs.SetInt("player1skin", (int)Player1);
		PlayerPrefs.SetInt("player2skin", (int)Player2);

    }

}