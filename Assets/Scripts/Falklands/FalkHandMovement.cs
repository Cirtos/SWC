using UnityEngine;
using System.Collections;

public class FalkHandMovement : MonoBehaviour {

    public string xAxesName;
    public string yAxesName;
    public float moveSpeed;
    //public string axesName;
    

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    //private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis(xAxesName);
        moveY = Input.GetAxis(yAxesName);
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }

    void Update()
    {
       /* if (attackHand)
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
        */
    }
}
