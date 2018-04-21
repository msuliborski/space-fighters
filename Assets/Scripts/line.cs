using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{

    [SerializeField]
    float vel = -5f;

    [SerializeField]
    GameObject player_1;

    [SerializeField]
    GameObject player_2;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(vel, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((player_1.transform.position.x == transform.position.x) && (player_2.transform.position.x == transform.position.x)) Draw();
        if (player_1.transform.position.x == transform.position.x) Player_1Wins();
        if (player_2.transform.position.x == transform.position.x) Player_2Wins();
    }
    void Draw()
    {

    }
    void Player_1Wins()
    {

    }
    void Player_2Wins()
    {

    }
}
