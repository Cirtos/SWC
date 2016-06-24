using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public string axesName;
    public Sprite buttonUnpressed;
    public Sprite buttonPressed;
    public bool isRussia;
    public GameObject enemyHand;
    public GameObject playerHand;
    public float buttonRange;
	public AudioClip ButtonSound;
	private AudioSource source;

    private SpriteRenderer spRend;
    private GameManager gManager;
    private float buttonRangeCheck;
    private float defendRangeCheck;
    public bool pressed;
    private bool triggerPulled;

    // Use this for initialization
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
        gManager = FindObjectOfType<GameManager>();
		source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        buttonRangeCheck = Vector2.Distance(enemyHand.transform.position, transform.position);
        defendRangeCheck = Vector2.Distance(playerHand.transform.position, transform.position);

        if (!gManager.gameoveryeh)
        {            
            if (!pressed)
            {
                if (Input.GetButtonDown(axesName))
                {
                    if (buttonRangeCheck <= buttonRange)
                    {
                        if (defendRangeCheck > buttonRange)
                        {
                                pressed = true;
								source.PlayOneShot(ButtonSound);
                                spRend.sprite = buttonPressed;
                                if (isRussia)
									
                                    gManager.ameButtonCount++;
                                else 
                                    gManager.rusButtonCount++;
                        }
                    }
                }
            }
        }
    }

    public void Reset(string side)
    {
        if (side == "America" && !isRussia)
        {
            spRend.sprite = buttonUnpressed;
            gManager.ameButtonCount--;
        }
        else if (side == "Russia" && isRussia)
        {
            spRend.sprite = buttonUnpressed;
            gManager.rusButtonCount--;
        } 
    }
}