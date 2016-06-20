using UnityEngine;
using System.Collections;

public class Menu_Confirm_Transition : MonoBehaviour {

    public string sceneToTrans;

    private bool focus;
    private string colTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (focus == true)
        {
            if(colTag == "Russia")
            {
                if (Input.GetButtonDown("P2 Fire"))
                {
                    Application.LoadLevel(sceneToTrans);
                }
            }
            else if (colTag == "America")
            {
                if (Input.GetButtonDown("P1 Fire"))
                {
                    Application.LoadLevel(sceneToTrans);
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        focus = true;
        colTag = col.gameObject.tag;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        focus = false;
        colTag = "";
    }
}
