using UnityEngine;
using System.Collections;

public class Voter : MonoBehaviour
{

    public bool onLand;
    private FalkGameManager gManager;

    // Use this for initialization
    void Start()
    {
        gManager = FindObjectOfType<FalkGameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (onLand)
        {
            if (tag == "GBRvoter")
            {
                gManager.gbrVoterCount++;
                onLand = false;
            }
            else
            {
                gManager.argVoterCount++;
                onLand = false;
            }
        }
        else
        {
            //is in water
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = true;
            print("col enter");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = true;
            print("trig enter");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Land")
        {
            onLand = false;
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
            print("removed");
        }
    }
}
