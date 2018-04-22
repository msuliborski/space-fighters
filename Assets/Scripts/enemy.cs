using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject explosion;
    public GameObject bullet;
    public float hp = 1;

    public GameObject _player1;
    public GameObject _player2;
    public GameObject _targetPlayer;
    private Rigidbody2D _rb;

    private float _dist1;
    private float _dist2;

    private float _targetTimer = 0;
    private bool _endTimer = false;
    private Vector2 _heading;
    private AudioSource source;
    public AudioClip jeb;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "bullet")
        {
            Destroy(collision.gameObject);
            hp--;
            if (hp == 0)
            {
                source.PlayOneShot(source.clip);
                gameObject.SetActive(false);
                Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            }
            
        }
    }

    // Use this for initialization
    void Start()
    {
        _player1 = GameObject.Find("player_1");
        _player2 = GameObject.Find("player_2");
        source = GetComponent<AudioSource>();

        if (_player1 && _player2)
        {
            _dist1 = Vector2.Distance(_player1.transform.position, transform.position);
            _dist2 = Vector2.Distance(_player2.transform.position, transform.position);
            if (_dist1 <= _dist2) _targetPlayer = _player1;
            else _targetPlayer = _player2;
        }
        else if (_player1) _targetPlayer = _player1;
        else _targetPlayer = _player2;

        _rb = GetComponent<Rigidbody2D>();




    }

    // Update is called once per frame
    void Update()
    {
        _targetTimer += Time.deltaTime;
        if(_targetPlayer)
        {
            if (_targetTimer <= 0.7) transform.position = Vector2.MoveTowards(transform.position, _targetPlayer.transform.position, 10 * Time.deltaTime);
            else
            {
                if (!_endTimer)
                {
                    _endTimer = true;
                    _heading = _targetPlayer.transform.position - transform.position;
                    _heading.Normalize();
                    Debug.Log(_heading.x);
                    Debug.Log(_heading.y);
                    Debug.Log(_rb.velocity);

                }

                _rb.velocity = new Vector2(5 * _heading.x, 5 * _heading.y);
            }
           
        }
        else _rb.velocity = new Vector2(5.0f, 0f);

    }
}
