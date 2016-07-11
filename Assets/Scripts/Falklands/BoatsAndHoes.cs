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

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    private Animator anim;
    private bool handOver;
    private bool holding;
    private GameObject voter;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(handOver)
        {
            if(!holding && Input.GetButtonDown(fireButton))
            {
                holding = true;
                voter = Instantiate(voterPrefab);
                voter.transform.parent = teamHand.transform;
            }
            
        }
        if (holding && Input.GetButtonUp(fireButton))
        {
            holding = false;
            voter.transform.parent = null;
        }
    }

    void FixedUpdate()
    {
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
        }
        else
        {
            if(col.gameObject.tag == "America")
            {
                handOver = true;
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
