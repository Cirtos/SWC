using UnityEngine;
using System.Collections;

public class Mode_Confirm : MonoBehaviour
{
    public string levelToLoad;

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
                    if (levelToLoad != "")
                        Application.LoadLevel(levelToLoad);
                }

            }
            else if (colTag == "America")
            {
                if (Input.GetButtonDown("P1 Fire"))
                {
                    if (levelToLoad != "")
                        Application.LoadLevel(levelToLoad);
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
