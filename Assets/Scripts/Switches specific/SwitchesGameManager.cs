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
    public GameObject muricawin;
    public GameObject ruskieswin;
    public SecondTimer levelTimer;
    public bool gameNotStarted;
    public bool gameOver;

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
        }
        else
        {
            ameAnthem.SetActive(true);
            muricawin.SetActive(true);
        }
        levelTimer.StopTimer();
        gameEndButtons.SetActive(true);
        gameOver = true;
    }
}
