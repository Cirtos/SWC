using UnityEngine;
using System.Collections;

public class Menu_Confirm_Transition : MonoBehaviour {

    public string sceneToTrans;
    public string pTaggedAsRussiaButton;
    public string pTaggedAsAmericaButton;

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
                if (Input.GetButtonDown(pTaggedAsRussiaButton))
                {
                    Application.LoadLevel(sceneToTrans);
                }
            }
            else if (colTag == "America")
            {
                if (Input.GetButtonDown(pTaggedAsAmericaButton))
                {
                    Application.LoadLevel(sceneToTrans);
                }
            }
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        focus = true;
        if(col.gameObject.tag == "America" || col.gameObject.tag == "Russia")
            colTag = col.gameObject.tag;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        focus = false;
        colTag = "";
    }
}
