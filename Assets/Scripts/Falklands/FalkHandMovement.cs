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
    public GameObject voterHold;
    public GameObject enemyVoterHold;
    public Transform finger;
    
    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    private Animator anim;
    private string voterAle;
    private bool holding;
    private GameObject voterOver;
    private bool holdingEnemyVoter;
    private FalkGameManager gManager;
    private All_Screens_Manager pause;

    // Use this for initialization
    void Start()
    {
        voterHold.SetActive(false);
        enemyVoterHold.SetActive(false);
        gManager = FindObjectOfType<FalkGameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pause = FindObjectOfType<All_Screens_Manager>();
    }

    void FixedUpdate()
    {
        if (pause.paused)
            return;

        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void Update()
    {

        if (gManager.gameOver || gManager.gameNotStarted || pause.paused)
        {
            return;
        }

        if (teamBoat.handOver)
        {
            if (!holding && Input.GetButtonDown(fireButton) && teamBoat.voterCount > 0)
            {
                holding = true;
                teamBoat.voterCount--;
            }

        }

        if (holding && Input.GetButtonUp(fireButton))
        {
            GameObject voteToSpawn = holdingEnemyVoter ? enemyVoterPrefab : voterPrefab;
            GameObject spawnedVoter = Instantiate(voteToSpawn);
            spawnedVoter.transform.position = finger.transform.position;
            holding = false;
            holdingEnemyVoter = false;
            voterHold.SetActive(false);
            enemyVoterHold.SetActive(false);
            anim.SetBool("holding", false);
        }


        if (voterAle != "")
        {
            if (isGB)
            {
                if (voterAle == "ARG" && Input.GetButtonDown(fireButton))
                {
                    voterOver.GetComponent<Voter>().Removal();
                    holding = true;
                    holdingEnemyVoter = true;
                }
            }
            else
            {
                if (voterAle == "GBR" && Input.GetButtonDown(fireButton))
                {
                    voterOver.GetComponent<Voter>().Removal();
                    holding = true;
                    holdingEnemyVoter = true;
                }
            }
        }

        if (holding)
        {
            if (holdingEnemyVoter)
                enemyVoterHold.SetActive(true);
            else
                voterHold.SetActive(true);

            anim.SetBool("holding", true);
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
        if (col.gameObject.tag == "GBRvoter")
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
