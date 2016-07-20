using UnityEngine;
using System.Collections;

public class Voter : MonoBehaviour
{

    public bool onLand;
    private bool placedOnLand;
    private FalkGameManager gManager;
    private bool flagDelete;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        gManager = FindObjectOfType<FalkGameManager>();
        anim = GetComponent<Animator>();
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
