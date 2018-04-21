using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject explosion;
    public GameObject bullet;
    public float hp = 1;

    private GameObject _player1;
    private GameObject _player2;
    private GameObject _targetPlayer;
    private Rigidbody2D _rb;

    private float _dist1;
    private float _dist2;

    private float _targetTimer = 0;
    private bool _endTimer = false;
    private Vector2 _heading;
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "bullet")
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        _player1 = GameObject.Find("player_1");
        _player2 = GameObject.Find("player_2");

        if (_player1 && _player2)
        {
            _dist1 = Vector2.Distance(_player1.transform.position, transform.position);
            _dist2 = Vector2.Distance(_player2.transform.position, transform.position);
            if (_dist1 <= _dist2) _targetPlayer = _player1;
            else _targetPlayer = _player2;
        }
        else if (_player1) _targetPlayer = _player1;
        else _targetPlayer = _player2;


            
        

	}
	
	// Update is called once per frame
	void Update () {
        _targetTimer += Time.deltaTime;

        if (_targetTimer <= 0.7 && _targetPlayer) transform.position = Vector2.MoveTowards(transform.position, _targetPlayer.transform.position, 10 * Time.deltaTime);
        else
        {
            if (!_endTimer)
            {
                _endTimer = true;
                _heading = _targetPlayer.transform.position - transform.position;
                _heading = _heading / (_heading.magnitude);
                _rb.velocity = 2*_heading;
            }
            _rb.velocity = 2 * _heading;
        }

    }
}
