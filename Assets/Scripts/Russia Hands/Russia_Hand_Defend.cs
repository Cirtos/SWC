using UnityEngine;
using System.Collections;

public class Russia_Hand_Defend : MonoBehaviour {

    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("RDHorizontal");
        moveY = Input.GetAxis("RDVertical");
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}
