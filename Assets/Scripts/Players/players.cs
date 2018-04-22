using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class players : MonoBehaviour
{

	private SpriteRenderer spriteRenderer; 
	public Sprite skin1;
	public Sprite skin2;
	public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;


    private Animator animator; 
	public RuntimeAnimatorController anim1; 
	public RuntimeAnimatorController anim2; 
	public RuntimeAnimatorController anim3;
    public RuntimeAnimatorController anim4;
    public RuntimeAnimatorController anim5;

    public float maxHP = 100f;
    public float HP = 100f;

    private Transform healthBar;

    public Text textHP;
    
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

    int r, a, b;

    GameObject go;
    private Rigidbody2D _rb;
    private AudioSource source;
    private AudioSource source_2;

    KeyCode upKey;
    KeyCode downKey;
    KeyCode leftKey;
    KeyCode rightKey;
    KeyCode fireKey;

    void OnCollisionEnter2D(Collision2D collision)
    {
        source.clip = jeb;
        if (collision.gameObject.transform.tag == "enemy"){
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            source.PlayOneShot(jeb, 1f);
            Destroy(collision.gameObject);
            HP -= 10;
            if (HP <= 0) dead();
        }
        else if (collision.gameObject.transform.tag == "bullet"){
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            source.PlayOneShot(jeb, 1f);
            Destroy(collision.gameObject);
            HP -= 5;
            if (HP <= 0) dead();
        }
        else if (collision.gameObject.transform.tag == "asteroid"){
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            source.PlayOneShot(jeb, 1f);
            Destroy(collision.gameObject);
            HP -= 20;
            if (HP <= 0) dead();
        }
    }

    void dead(){
        gameObject.SetActive(false);
        _rb.transform.position = new Vector3(-50, -50, -50);
    }

    // Use this for initialization
    void Start()
    {
        a = Random.Range(0, 5);
        b = Random.Range(0, 5);
        while (b == a) b = Random.Range(0, 2);

        if (playerNumber)
        {
            switch (a)
            {
                case 0:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim1;
                       // this.GetComponent<SpriteRenderer>.
                    }
                    break;
                case 1:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim2;
                    }
                    break;
                case 2:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim3;
                    }
                    break;
                case 3:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim4;
                    }
                    break;
                case 4:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim5;
                    }
                    break;

            }
        }
        else
        {
            switch (b)
            {
                case 0:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim1;
                    }
                    break;
                case 1:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim2;
                    }
                    break;
                case 2:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim3;
                    }
                    break;
                case 3:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim4;
                    }
                    break;
                case 4:
                    {
                        this.GetComponent<Animator>().runtimeAnimatorController = anim5;
                    }
                    break;
            }
        }
        //spriteRenderer = GetComponent<SpriteRenderer>();


        
        source = GetComponent<AudioSource>();
        source_2 = GetComponent<AudioSource>();
        source.clip = jeb;
        source_2.clip = pju;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber) textHP.text = "   Player 1: " + HP + " / " + maxHP;
        else textHP.text = "   Player 2: " + HP + " / " + maxHP;

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
            source_2.PlayOneShot(pju, 1f);
            Destroy(go, 3f);
        }

        
    }
}
