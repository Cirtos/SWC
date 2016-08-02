using UnityEngine;
using System.Collections;

public class Pause_Hands : MonoBehaviour {


    public GameObject[] lanes;
    public string yAxesName;
    public string fireButton;
    public int startLane;

    private All_Screens_Manager pause;
    private float moveY;
    private int currentLane;
    private bool moving;

    // Use this for initialization
    void Start()
    {
        transform.position = lanes[startLane].transform.position;
        currentLane = startLane;
        pause = FindObjectOfType<All_Screens_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        moveY = Input.GetAxis(yAxesName);

        if (moveY > -0.5 && moveY < 0.5)
            moving = false;
        if (moveY > 0.5 && !moving)
        {
            if (currentLane == 0)
            {
                transform.position = lanes[lanes.Length - 1].transform.position;
                moving = true;
                currentLane = lanes.Length - 1;
                return;
            }
            transform.position = lanes[currentLane - 1].transform.position;
            moving = true;
            currentLane--;
        }
        if (moveY < -0.5 && !moving)
        {
            if (currentLane == lanes.Length - 1)
            {
                transform.position = lanes[0].transform.position;
                moving = true;
                currentLane = 0;
                return;
            }
            transform.position = lanes[currentLane + 1].transform.position;
            moving = true;
            currentLane++;
        }

        if (Input.GetButtonDown(fireButton))
        {
            if (currentLane == 2)
            {
                Application.LoadLevel("Menu");
                pause.ClearPause();
                currentLane = 0;
            }
            else if (currentLane == 1)
            {
                Application.LoadLevel(Application.loadedLevel);
                pause.ClearPause();
                currentLane = 0;
            }
            else
                pause.ClearPause();
        }       
    }
}
