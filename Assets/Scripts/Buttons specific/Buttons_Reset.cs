using UnityEngine;
using System.Collections;

public class Buttons_Reset : MonoBehaviour {

    public Sprite red;
    public Sprite orange;
    public Sprite green;
    public float resetTime;
    public Button[] buttons;
    public bool isRussia;

    private bool focus;
    private string colTag;
    private float buttonDown;
    private GameManager gManager;
    private SpriteRenderer sprite;


	// Use this for initialization
	void Start () {
        gManager = FindObjectOfType<GameManager>();
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!gManager.gameoveryeh)
        {
            if (isRussia)
            {
                if (gManager.ameButtonCount >= 1)
                    sprite.sprite = green;
                else
                    sprite.sprite = red;
            }

            else
            {
                if(gManager.rusButtonCount >=1)
                    sprite.sprite = green;
                else
                    sprite.sprite = red;
            }

            if (focus == true)
            {
                if (colTag == "Russia" && isRussia)
                {
                    if (Input.GetButtonDown("P2 Fire"))
                    {
                        buttonDown = Time.time;
                    }
                    if (Input.GetButton("P2 Fire"))
                    {
                        if (gManager.ameButtonCount >= 1)
                            sprite.sprite = orange;
                        if (Time.time > (buttonDown + resetTime))
                        {
                            foreach (Button button in buttons)
                            {
                                button.Reset("Russia");
                            }
                        }
                    }
                }
                else if (colTag == "America" && !isRussia)
                {
                    if (Input.GetButtonDown("P1 Fire"))
                    {
                        buttonDown = Time.time;
                        
                    }
                    if (Input.GetButton("P1 Fire"))
                    {
                        if (gManager.rusButtonCount >= 1)
                            sprite.sprite = orange;
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
            if (!focus)
                buttonDown = Time.time;
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
