using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class players : MonoBehaviour
{

    
    public float hp = 100f;
    
    public float vel = 5f;

    public bool playerNumber;

    public GameObject bullet;

    public GameObject instPoint;

    private float playerWidth;
    private float playerHeight;
    private float bulletWidth;
    private float bulletHeight;

    GameObject go;
    private Rigidbody2D _rb;

    KeyCode upKey;
    KeyCode downKey;
    KeyCode leftKey;
    KeyCode rightKey;
    KeyCode fireKey;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "enemy")
        {
            Destroy(collision.gameObject);
            hp -= 10;

            if (hp == 0) Destroy(gameObject);
        }
        else if (collision.gameObject.transform.tag == "bullet")
        {
            Destroy(collision.gameObject);
            hp -= 5;

            if (hp == 0) Destroy(gameObject);
        }
    }

   

    



    // Use this for initialization
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _rb.isKinematic = true;
        playerWidth = _rb.transform.localScale.x;
        playerHeight = _rb.transform.localScale.y;
        bulletHeight = bullet.transform.localScale.x;
        bulletWidth = bullet.transform.localScale.y;

        instPoint.transform.localScale = new Vector2(_rb.transform.position.x + playerWidth + bulletWidth/2, _rb.transform.position.y);


        if (playerNumber)
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
            fireKey = KeyCode.T;
        }
        else
        {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
            leftKey = KeyCode.LeftArrow;
            rightKey = KeyCode.RightArrow;
            fireKey = KeyCode.Period;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(upKey)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
        else if (Input.GetKey(upKey)) _rb.velocity = new Vector3(_rb.velocity.x, vel, 0);

        if (Input.GetKeyUp(downKey)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
        else if (Input.GetKey(downKey)) _rb.velocity = new Vector3(_rb.velocity.x, -vel, 0);

        if (Input.GetKeyUp(leftKey)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        else if (Input.GetKey(leftKey)) _rb.velocity = new Vector3(-vel, _rb.velocity.y, 0);

        if (Input.GetKeyUp(rightKey)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        else if (Input.GetKey(rightKey)) _rb.velocity = new Vector3(vel, _rb.velocity.y, 0);

        if (Input.GetKeyDown(fireKey))
        {
            go = Instantiate(bullet, instPoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = vel * Vector2.right;
            Destroy(go, 3f);
        }

    }
}
