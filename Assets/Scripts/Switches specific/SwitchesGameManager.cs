using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchesGameManager : MonoBehaviour {

    public float startDelay;
    public int ameSwitches;
    public int rusSwitches;
    public GameObject rusNukeButton;
    public GameObject ameNukeButton;
    public GameObject gameEndButtons;
    public GameObject ameAnthem;
    public GameObject rusAnthem;
    public Text rusNumber;
    public Text murNumber;
    public Text countdown;
    public GameObject muricawin;
    public GameObject ruskieswin;
    public Background_Music bg;
    public SecondTimer levelTimer;
    public bool gameNotStarted;
    public bool gameOver;
    public bool rusNuke;
    public bool ameNuke;

    private float startTime;

    // Use this for initialization
    void Start () {

        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
        gameEndButtons.SetActive(false);

        startTime = Time.time;
        gameNotStarted = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameNotStarted)
        {
            float cdf = Mathf.Ceil((startTime + startDelay) - Time.time);
            int cd = (int)cdf;
            countdown.text = cd.ToString();
            if (cd == 0)
            {
                countdown.text = "Go!";
            }
        }

        if (((startTime + startDelay) - Time.time) < -1)
        {
            countdown.text = "";
        }

        rusNumber.text = "0" + rusSwitches.ToString();
        murNumber.text = "0" + ameSwitches.ToString();

        if (Time.time > (startTime + startDelay))
        {
            if (gameNotStarted)
            {
                levelTimer.GameStart();
                gameNotStarted = false;
            }
        }

    }

    public void NukePressed(string nukePressed)
    {
        if(nukePressed == "America")
        {
            rusAnthem.SetActive(true);
            ruskieswin.SetActive(true);
            ameNuke = true;
            
        }
        else
        {
            ameAnthem.SetActive(true);
            muricawin.SetActive(true);
            rusNuke = true;
        }
        levelTimer.StopTimer();
        gameEndButtons.SetActive(true);
        gameOver = true;
        bg.Victory();
    }
}
