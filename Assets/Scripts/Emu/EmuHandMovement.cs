using UnityEngine;
using System.Collections;

public class EmuHandMovement : MonoBehaviour {

    public GameObject[] lanes;
    public string xAxesName;
    public string yAxesName;
    public float moveSpeed;
    public string fireButton;
    public int startLane;
    public float shotDelay;
    public float shotTimeout;
    public bool isEmu;
    public GameObject emu;
    public GameObject bullet;
    public GameObject emuPlayer;
    public GameObject jeepPlayer;
    public Sprite p1Hand;
    public Sprite p2Hand;
    public Transform projectileSpawner;
    public Animator anim;
    public AudioClip fire;

    private EmuGameManager gManager;
    private float moveX;
    private float moveY;
    private int currentLane;
    private bool moving;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool gameOverSwap;
    private float lastShot;
    private All_Screens_Manager pause;
    private AudioSource audi;

	// Use this for initialization
	void Start () {
        transform.position = lanes[startLane].transform.position;
        currentLane = startLane;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gManager = FindObjectOfType<EmuGameManager>();
        anim = GetComponent<Animator>();
        pause = FindObjectOfType<All_Screens_Manager>();
        audi = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if(gManager.gameOver || gManager.gameNotStarted || pause.paused)
        {
            return;
        }

        moveY = Input.GetAxis(yAxesName);

        if (moveY > -0.5 && moveY < 0.5)
            moving = false;
        if (moveY > 0.5 && !moving)
        {
            if(currentLane == 0)
            {
                transform.position = lanes[lanes.Length - 1].transform.position;
                moving = true;
                currentLane = lanes.Length - 1;
                return;
            }
            transform.position = lanes[currentLane - 1].transform.position;
            moving = true;
            currentLane--;
        }
        if (moveY < -0.5 && !moving)
        {
            if(currentLane == lanes.Length - 1)
            {
                transform.position = lanes[0].transform.position;
                moving = true;
                currentLane = 0;
                return;
            }
            transform.position = lanes[currentLane + 1].transform.position;
            moving = true;
            currentLane++;
        }
        if(Input.GetButtonDown(fireButton))
        {
            if (Time.time > lastShot + shotDelay)
            {
                if (isEmu)
                {
                    Instantiate(emu, projectileSpawner.transform.position, Quaternion.identity);
                    lastShot = Time.time;
                }
                else
                {
                    Instantiate(bullet, projectileSpawner.transform.position, Quaternion.identity);
                    anim.SetTrigger("Shoot");
                    lastShot = Time.time;
                    audi.PlayOneShot(fire, 0.5f);
                }
            }
        }
        if (isEmu)
        {
            if (Time.time > lastShot + shotTimeout)
            {
                Instantiate(emu, projectileSpawner.transform.position, Quaternion.identity);
                lastShot = Time.time;
            }
        }
    }

    void FixedUpdate()
    {
        if (pause.paused)
            return;

        if (gManager.gameOver)
        {
            if (!gameOverSwap)
            {
                if (isEmu)
                {
                    gameOverSwap = true;
                    //Instantiate(emuPlayer, transform.position, Quaternion.identity);
                    sprite.sprite = p2Hand;
                    Destroy(anim);
                    transform.localScale = new Vector3 (4, 4, 4);
                    sprite.sortingOrder = 2;
                }
                else
                {
                    gameOverSwap = true;
                    //Instantiate(jeepPlayer, transform.position, Quaternion.identity);
                    sprite.sprite = p1Hand;
                    Destroy(anim);
                    transform.localScale = new Vector3(4, 4, 4);
                    sprite.sortingOrder = 2;
                }
            }
            
            moveX = Input.GetAxis(xAxesName);
            moveY = Input.GetAxis(yAxesName);
            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        }
    }
}
