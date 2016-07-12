using UnityEngine;
using System.Collections;

public class FalkHandMovement : MonoBehaviour {

    public string xAxesName;
    public string yAxesName;
    public string fireButton;
    public float moveSpeed;
    public BoatsAndHoes teamBoat;
    public GameObject voterPrefab;
    public GameObject enemyVoterPrefab;
    public bool isGB;
    
    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    //private Animator anim;
    private string voterAle;
    private bool holding;
    private GameObject voterOver;
    private bool holdingEnemyVoter;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void Update()
    {
        if (teamBoat.handOver)
        {
            if (!holding && Input.GetButtonDown(fireButton) && teamBoat.voterCount > 0)
            {
                holding = true;
                teamBoat.voterCount--;
                //voter.transform.parent = teamHand.transform;
            }

        }

        if (holding && Input.GetButtonUp(fireButton))
        {
            GameObject voteToSpawn = holdingEnemyVoter ? enemyVoterPrefab : voterPrefab;
            GameObject spawnedVoter = Instantiate(voteToSpawn);
            spawnedVoter.transform.position = transform.position;
            holding = false;
            holdingEnemyVoter = false;
        }


        if (voterAle != "")
        {
            if (isGB)
            {
                if (voterAle == "GBR" && Input.GetButtonDown(fireButton))
                {
                    Destroy(voterOver);
                    holding = true;
                }
                else if (voterAle == "ARG" && Input.GetButtonDown(fireButton))
                {
                    Destroy(voterOver);
                    holding = true;
                    holdingEnemyVoter = true;
                }
            }
            else
            {
                if (voterAle == "ARG" && Input.GetButtonDown(fireButton))
                {
                    Destroy(voterOver);
                    holding = true;
                }
                else if (voterAle == "GBR" && Input.GetButtonDown(fireButton))
                {
                    Destroy(voterOver);
                    holding = true;
                    holdingEnemyVoter = true;
                }
            }
        }

            /* if (attackHand)
             {
                 if (isRussia)
                 {
                     if (Input.GetButtonDown(axesName))
                     {
                         anim.SetTrigger("RusPressed");
                     }
                 }
                 else if (!isRussia)
                 {
                     if (Input.GetButtonDown(axesName))
                     {
                         anim.SetTrigger("MurPressed");
                     }
                 }
             }
             */
        }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "GBRVoter")
        {
            voterAle = "GBR";
            voterOver = col.gameObject;
        }

        if (col.gameObject.tag == "ARGvoter")
        {
            voterAle = "ARG";
            voterOver = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        voterAle = "";
        voterOver = null;
    }
}
