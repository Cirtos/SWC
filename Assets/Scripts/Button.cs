using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public string axesName;
    public Sprite buttonPressed;
    public bool isRussia;
    public GameObject enemyHand;
    public GameObject playerHand;
    public float buttonRange;

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
}