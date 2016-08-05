using UnityEngine;
using System.Collections;

public class Pause_Hands : MonoBehaviour {


    public GameObject[] lanes;
    public string yAxesName;
    public string fireButton;
    public int startLane;
    public AudioClip move;
    public AudioClip select;

    private All_Screens_Manager pause;
    private float moveY;
    private int currentLane;
    private bool moving;
    private AudioSource audi;

    // Use this for initialization
    void Start()
    {
        transform.position = lanes[startLane].transform.position;
        currentLane = startLane;
        pause = FindObjectOfType<All_Screens_Manager>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        moveY = Input.GetAxis(yAxesName);

        if (moveY > -0.5 && moveY < 0.5)
            moving = false;
        if (moveY > 0.5 && !moving)
        {
            audi.PlayOneShot(move, 1f);
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
            audi.PlayOneShot(move, 1f);
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
            audi.PlayOneShot(select, 1f);
            if (currentLane == 2)
            {
                transform.position = lanes[0].transform.position;
                currentLane = 0;
                pause.ClearPause();
                Application.LoadLevel("Menu");
                
            }
            else if (currentLane == 1)
            {
                transform.position = lanes[0].transform.position;
                currentLane = 0;
                pause.ClearPause();
                Application.LoadLevel(Application.loadedLevel);
            }
            else
            {
                pause.ClearPause();
                pause.ReturnCanvas();
                currentLane = 0;
            }
        }       
    }
}
