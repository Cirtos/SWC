using UnityEngine;
using System.Collections;

public class HandMovement : MonoBehaviour
{
    public string xAxesName;
    public string yAxesName;
    public bool attackHand;
    public float moveSpeed;
    public string axesName;
    public bool isRussia;

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    private Animator anim;
    private All_Screens_Manager pause;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pause = FindObjectOfType<All_Screens_Manager>();
    }

    void FixedUpdate()
    {
        if (pause.paused)
        {
            rb.velocity = new Vector2(moveX * 0, moveY * 0);
            return;
        }

        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void Update()
    {
        if (pause.paused)
            return;

        if (attackHand)
        {
            if (isRussia)
            {
                if (Input.GetButtonDown(axesName))
                {
                     anim.SetTrigger("RusPressed");
                }
            }
            else if (!isRussia)
            {
                if (Input.GetButtonDown(axesName))
                {
                    anim.SetTrigger("MurPressed");
                }
            }
        }
    }
}
