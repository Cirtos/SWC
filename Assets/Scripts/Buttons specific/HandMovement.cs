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

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
 
    }

    void Update()
    {
        if (attackHand)
        {
            if (isRussia)
            {
                if (Input.GetAxis(axesName) >= 0.5)
                {
                     anim.SetTrigger("RusPressed");
                }
            }
            else if (!isRussia)
            {
                if (Input.GetAxis(axesName) >= 0.5)
                {
                    anim.SetTrigger("MurPressed");
                }
            }
        }
    }
}
