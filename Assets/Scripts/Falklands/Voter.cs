using UnityEngine;
using System.Collections;

public class Voter : MonoBehaviour {

    private bool onLand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            if(onLand)
            {
                //game manager vote count ++
            }
            else
            {
                //is in water
            }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Land")
        {
            onLand = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Land")
        {
            onLand = false;
        }
    }
}
