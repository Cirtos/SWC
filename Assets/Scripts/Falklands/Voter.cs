using UnityEngine;
using System.Collections;

public class Voter : MonoBehaviour
{
    public AudioClip[] splash;
    public bool onLand;

    private bool placedOnLand;
    private FalkGameManager gManager;
    private bool flagDelete;
    private Animator anim;
    private AudioSource audi;
    private bool playedSplash;
    private float splashDelay = 0.05f;
    private float spawnTime;

    // Use this for initialization
    void Start()
    {
        gManager = FindObjectOfType<FalkGameManager>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagDelete)
            Destroy(gameObject);

        
        if (placedOnLand)
        {
            if (tag == "GBRvoter")
            {
                gManager.gbrVoterCount++;
            }
            else if (tag == "ARGvoter")
            {
                gManager.argVoterCount++;
            }
            anim.SetBool("onLand", true);
            placedOnLand = false;
        }

        if (!onLand && !playedSplash && Time.time > (spawnTime + splashDelay))
        {
            int clipToPlay = Random.Range(0, splash.Length);
            audi.PlayOneShot(splash[clipToPlay], 1f);
            playedSplash = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = true;
            placedOnLand = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = false;
            placedOnLand = false;
        }
    }

    public void Removal()
    {
        if(onLand)
        {
            if (tag == "GBRvoter")
            {
                gManager.gbrVoterCount--;
            }
            else
            {
                gManager.argVoterCount--;                
            }
        }

        flagDelete = true;
    }
}
