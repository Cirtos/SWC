using UnityEngine;
using System.Collections;

public class Mode_Select : MonoBehaviour {
    
    public string levelToLoad;
    public Sprite button;
    public Sprite buttonPressed;
    public AudioClip pressSound;

    private SpriteRenderer sprite;
    private Mode_Confirm modeConfirm;
    private bool selected;
    private Mode_Select[] modeButtons;
    private bool focus;
    private string colTag;
    private AudioSource audi;
    private bool hasPlayed;

    // Use this for initialization
    void Start () {
        modeButtons = FindObjectsOfType<Mode_Select>();
        sprite = GetComponent<SpriteRenderer>();
        modeConfirm = FindObjectOfType<Mode_Confirm>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
            sprite.sprite = buttonPressed;
        else
            sprite.sprite = button;

        if (!selected)
            hasPlayed = false;

        if (focus == true)
        {
            if (colTag == "Russia")
            {
                if (Input.GetButtonDown("P2 Fire"))
                {
                    foreach (Mode_Select modeButton in modeButtons)
                    {
                        modeButton.selected = false;
                    }

                    selected = true;
                    modeConfirm.levelToLoad = levelToLoad;
                    if (!hasPlayed)
                    {
                        audi.PlayOneShot(pressSound, 1f);
                        hasPlayed = true;
                    }
                }
            }

            else if (colTag == "America")
            {
                if (Input.GetButtonDown("P1 Fire"))
                {
                    foreach (Mode_Select modeButton in modeButtons)
                    {
                        modeButton.selected = false;
                    }

                    selected = true;
                    modeConfirm.levelToLoad = levelToLoad;
                    if (!hasPlayed)
                    {
                        audi.PlayOneShot(pressSound, 1f);
                        hasPlayed = true;
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
