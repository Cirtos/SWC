using UnityEngine;
using System.Collections;

public class EmuHandMovement : MonoBehaviour {

    public GameObject[] lanes;
    public string xAxesName;
    public string yAxesName;
    public float moveSpeed;
    public string fireButton;
    public int startLane;
    public bool isEmu;
    public GameObject emu;
    public GameObject bullet;
    public GameObject emuPlayer;
    public GameObject jeepPlayer;
    public Sprite p1Hand;
    public Sprite p2Hand;

    private EmuGameManager gManager;
    private float moveX;
    private float moveY;
    private int currentLane;
    private bool moving;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool gameOverSwap;

	// Use this for initialization
	void Start () {
        transform.position = lanes[startLane].transform.position;
        currentLane = startLane;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gManager = FindObjectOfType<EmuGameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if(gManager.gameOver || gManager.gameNotStarted)
        {
            return;
        }

        moveY = Input.GetAxis(yAxesName);

        if (moveY > -0.5 && moveY < 0.5)
            moving = false;
        if (moveY > 0.5 && !moving && currentLane != 0)
        {
            transform.position = lanes[currentLane - 1].transform.position;
            moving = true;
            currentLane--;
        }
        if (moveY < -0.5 && !moving && currentLane != lanes.Length - 1)
        {
            transform.position = lanes[currentLane + 1].transform.position;
            moving = true;
            currentLane++;
        }
        if(Input.GetButtonDown(fireButton))
        {
            //lanes[currentLane].Pressed();
            if(isEmu)
            {
                Instantiate(emu, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }
    }

    void FixedUpdate()
    {
        if (gManager.gameOver)
        {
            if (!gameOverSwap)
            {
                if (isEmu)
                {
                    Instantiate(emuPlayer, transform.position, Quaternion.identity);
                    sprite.sprite = p2Hand;
                    transform.localScale = new Vector3 (4, 4, 4);
                    sprite.sortingOrder = 2;
                    gameOverSwap = true;
                }
                else
                {
                    Instantiate(jeepPlayer, transform.position, Quaternion.identity);
                    sprite.sprite = p1Hand;
                    transform.localScale = new Vector3(4, 4, 4);
                    sprite.sortingOrder = 2;
                    gameOverSwap = true;
                }
            }
            
            moveX = Input.GetAxis(xAxesName);
            moveY = Input.GetAxis(yAxesName);
            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        }
    }
}
