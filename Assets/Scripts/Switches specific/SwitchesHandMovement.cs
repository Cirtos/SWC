using UnityEngine;
using System.Collections;

public class SwitchesHandMovement : MonoBehaviour {

    public Switches[] buttons;
    public string xAxesName;
    public string yAxesName;
    public float moveSpeed;
    public string fireButton;
    // which button do they start over from 0 to 13
    public int startButton;

    private SwitchesGameManager gManager;
    private float moveX;
    private float moveY;
    private int currentButton;
    private bool moving;
    private Rigidbody2D rb;
    private All_Screens_Manager pause;

    // Use this for initialization
    void Start () {
        transform.position = buttons[startButton].transform.position;
        currentButton = startButton;
        rb = GetComponent<Rigidbody2D>();
        gManager = FindObjectOfType<SwitchesGameManager>();
        pause = FindObjectOfType<All_Screens_Manager>();
    }
	
	// Update is called once per frame
	void Update () {

        if(gManager.gameOver || gManager.gameNotStarted || pause.paused)
        {
            return;
        }

        moveX = Input.GetAxis(xAxesName);

        if (moveX > -0.5 && moveX < 0.5)
            moving = false;
        if (moveX > 0.5 && !moving && currentButton != 13)
        {
            transform.position = buttons[currentButton + 1].transform.position;
            moving = true;
            currentButton++;
        }
        if (moveX < -0.5 && !moving && currentButton != 0)
        {
            transform.position = buttons[currentButton - 1].transform.position;
            moving = true;
            currentButton--;
        }
        if(Input.GetButtonDown(fireButton))
        {
            buttons[currentButton].Pressed();
        }
    }

    void FixedUpdate()
    {
        if (gManager.gameOver)
        {
            moveX = Input.GetAxis(xAxesName);
            moveY = Input.GetAxis(yAxesName);
            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        }
    }
}
