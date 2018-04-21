using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class players : MonoBehaviour
{

    
    public float maxHP = 100f;
    public float HP = 100f;
    public float healthBarLength = 1;

    private Transform healthBar;


    
    
    public float vel = 5f;

    public bool playerNumber;

    public GameObject bullet;

    public GameObject instPoint;

    public GameObject explosion;

    public GameObject background;

    public GameObject BG;

    public AudioClip pju;

    public AudioClip jeb;

    public float playerWidth;
    public float playerHeight;
    public float bulletWidth;
    public float bulletHeight;
    public float backgroundWidth;
    public float backgroundHeight;
    public float backgroundOffsetX;
    public float backgroundOffsetY;

    int r;

    GameObject go;
    private Rigidbody2D _rb;
    private AudioSource source;

    KeyCode upKey;
    KeyCode downKey;
    KeyCode leftKey;
    KeyCode rightKey;
    KeyCode fireKey;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "enemy")
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            source.clip = jeb;
            source.PlayOneShot(source.clip, 1f);
            Destroy(collision.gameObject);
            HP -= 10;
            if (HP <= 0) gameObject.SetActive(false);
        }
        else if (collision.gameObject.transform.tag == "bullet")
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            source.clip = jeb;
            source.PlayOneShot(source.clip, 1f);
            Destroy(collision.gameObject);
            HP -= 5;
            if (HP <= 0) gameObject.SetActive(false);
        }
    }


    public void addHealth(int val) {
        HP += val;
       
        if (HP < 0)
            HP = 0;
       
        if (HP > maxHP)
            HP = maxHP;
       
        if(maxHP < 1)
            maxHP = 1;
       
        healthBarLength = (playerWidth/2) * (HP /(float)maxHP);
    }
    



    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _rb.isKinematic = true;
        playerWidth = GetComponent<Collider2D>().bounds.size.x;
        playerHeight = GetComponent<Collider2D>().bounds.size.y;
        bulletHeight = bullet.GetComponent<Collider2D>().bounds.size.x;
        bulletWidth = bullet.GetComponent<Collider2D>().bounds.size.y;
        background = GameObject.Find("background");
        backgroundHeight = background.GetComponent<MeshCollider>().bounds.size.y;
        backgroundWidth = background.GetComponent<MeshCollider>().bounds.size.x;
        backgroundOffsetX = background.GetComponent<MeshCollider>().transform.position.x;
        backgroundOffsetY = background.GetComponent<MeshCollider>().transform.position.y;

        instPoint.transform.position = new Vector2(_rb.transform.position.x + playerWidth + bulletWidth, _rb.transform.position.y);
        
        if (playerNumber)
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            leftKey = KeyCode.D;
            rightKey = KeyCode.A;
            fireKey = KeyCode.T;
        }
        else
        {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
            leftKey = KeyCode.RightArrow;
            rightKey = KeyCode.LeftArrow;
            fireKey = KeyCode.Period;
        }


        healthBarLength = playerWidth/2;
        healthBar = this.gameObject.transform.FindChild("healthBar");

    }

    // Update is called once per frame
    void Update()
    {

        if (((transform.position.y + playerHeight / 2) >= 4.5) || ((transform.position.y - playerHeight / 2) <= -4.5)) _rb.velocity = new Vector2(_rb.velocity.x, 0);

        if (((transform.position.x + playerWidth / 2) >= 8) || ((transform.position.x - playerWidth / 2) <= -8)) _rb.velocity = new Vector2(0, _rb.velocity.y);

        if (Input.GetKeyUp(upKey)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
        else if (Input.GetKey(upKey) && ((transform.position.y + playerHeight/2) < 4.5)) _rb.velocity = new Vector3(_rb.velocity.x, vel, 0);

        if (Input.GetKeyUp(downKey)) _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
        else if (Input.GetKey(downKey) && ((transform.position.y - playerHeight / 2) > -4.5)) _rb.velocity = new Vector3(_rb.velocity.x, -vel, 0);

        if (Input.GetKeyUp(leftKey)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        else if (Input.GetKey(leftKey) && ((transform.position.x + playerWidth / 2) < 8)) _rb.velocity = new Vector3(vel, _rb.velocity.y, 0);

        if (Input.GetKeyUp(rightKey)) _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        else if (Input.GetKey(rightKey) && ((transform.position.x - playerWidth / 2) > -8)) _rb.velocity = new Vector3(-vel, _rb.velocity.y, 0);

        if (Input.GetKeyDown(fireKey))
        {
            go = Instantiate(bullet, instPoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = vel* 1.5f * Vector2.right;
            source.clip = pju;
            source.PlayOneShot(source.clip, 1f);
            Destroy(go, 3f);
        }

        
    }
}
