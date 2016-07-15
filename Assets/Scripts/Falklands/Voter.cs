using UnityEngine;
using System.Collections;

public class Voter : MonoBehaviour
{

    private bool onLand;
    private bool placedOnLand;
    private FalkGameManager gManager;

    // Use this for initialization
    void Start()
    {
        gManager = FindObjectOfType<FalkGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
