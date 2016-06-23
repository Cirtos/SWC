using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float startDelay;
    public GameObject ameAnthem;
    public GameObject rusAnthem;
    public int rusButtonCount;
    public int ameButtonCount;
    public bool gameoveryeh;
    public GameObject muricawin;
    public GameObject ruskieswin;
    public Text rusNumber;
    public Text murNumber;
    public Text countdown;
    public GameObject afterGameButtons;
    public GameObject startBoundaries;
    public bool gameStart;
    public SecondTimer levelTimer;
    public Background_Music bg;

    private float startTime;

    void Awake()
    {
        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
        afterGameButtons.SetActive(false);

        startTime = Time.time;
        gameStart = true;
    }
	
	void Update () {

        if (gameStart)
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

        //Set the number to how many of own buttons pressed by enemy
        rusNumber.text = "0" + ameButtonCount.ToString();
        murNumber.text = "0" + rusButtonCount.ToString();

        if (rusButtonCount >= 5 || ameButtonCount >= 5)
        {
            if (rusButtonCount >= 5)
            {
                rusAnthem.SetActive(true);
                ruskieswin.SetActive(true);
            }

            else if (ameButtonCount >= 5)
            {
                ameAnthem.SetActive(true);
                muricawin.SetActive(true);
            }

            gameoveryeh = true;
            levelTimer.StopTimer();
            bg.Victory();
        }

        if(gameoveryeh)
        {
            afterGameButtons.SetActive(true);
        }

        if(Time.time > (startTime + startDelay))
        {
            if (gameStart)
            {
                startBoundaries.SetActive(false);
                levelTimer.GameStart();
                gameStart = false;
            }
        }
    }

    void Reset()
    {
        ameButtonCount = 0;
        rusButtonCount = 0;
        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        gameoveryeh = false;
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
    }
}
