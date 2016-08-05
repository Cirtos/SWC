using UnityEngine;
using System.Collections;

public class BoatsAndHoes : MonoBehaviour {

    public string xAxesName;
    public string yAxesName;
    public string fireButton;
    public float moveSpeed;
    public int voterCount;
    public bool isGB;
    public GameObject voterPrefab;
    public GameObject teamHand;
    public bool handOver;
    public AudioClip boatNoise;

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    private bool holding;
    private GameObject voter;
    private All_Screens_Manager pause;
    //private AudioSource audi;
    //private bool moving;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pause = FindObjectOfType<All_Screens_Manager>();
        //audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*
        if(moveX >= 0.5 && !moving || moveX <= -0.5 && !moving || moveY >= 0.5 && !moving || moveY <= -0.5 && !moving)
        {
            moving = true;
            audi.PlayOneShot(boatNoise, 1f);
        }
        if (moveX <= float.Epsilon && moveY <= float.Epsilon)
            moving = false;
            */
    }

    void FixedUpdate()
    {
        if (pause.paused)
            return;

        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isGB)
        {
            if (col.gameObject.tag == "Russia")
            {
                handOver = true;
            }
            else if (col.gameObject.tag == "GBRvoter")
            {
                Voter vote = col.GetComponentInParent<Voter>();
                if (!vote.onLand)
                {
                    Destroy(col.gameObject);
                    voterCount++;
                }
            }
        }
        else
        {
            if(col.gameObject.tag == "America")
            {
                handOver = true;
            }
            else if (col.gameObject.tag == "ARGvoter")
            {
                Voter vote = col.GetComponentInParent<Voter>();
                if (!vote.onLand)
                {
                    Destroy(col.gameObject);
                    voterCount++;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (isGB)
        {
            if (col.gameObject.tag == "Russia")
            {
                handOver = false;
            }
        }
        else
        {
            if (col.gameObject.tag == "America")
            {
                handOver = false;
            }
        }
    }
}
