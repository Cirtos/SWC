using UnityEngine;
using System.Collections;

public class Buttons_Reset : MonoBehaviour {

    public float resetTime;
    public Button[] buttons;
    public bool isRussia;

    private bool focus;
    private string colTag;
    private float buttonDown;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (focus == true)
        {
            if (colTag == "Russia" && isRussia)
            {
                if (Input.GetButtonDown("P2 Fire"))
                    buttonDown = Time.time;
                if (Input.GetButton("P2 Fire"))
                {
                    if (Time.time > (buttonDown + resetTime))
                    {
                        foreach(Button button in buttons)
                        {
                            button.Reset("Russia");
                        }
                    }
                }
            }
            else if (colTag == "America" && !isRussia)
            {
                if (Input.GetButtonDown("P1 Fire"))
                    buttonDown = Time.time;
                if (Input.GetButton("P1 Fire"))
                {
                    buttonDown = Time.time;
                    if (Time.time > (buttonDown + resetTime))
                    {
                        foreach (Button button in buttons)
                        {
                            button.Reset("America");
                        }
                    }
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
