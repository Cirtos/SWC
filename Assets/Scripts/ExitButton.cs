using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    private bool focus;
    private string colTag;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (focus == true)
        {
            if (colTag == "Russia")
            {
                if (Input.GetButtonDown("P2 Fire"))
                {
                    Application.Quit();
                }
            }
            else if (colTag == "America")
            {
                if (Input.GetButtonDown("P1 Fire"))
                {
                    Application.Quit();
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