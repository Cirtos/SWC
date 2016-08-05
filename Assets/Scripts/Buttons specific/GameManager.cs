using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float startDelay;
    public GameObject ameAnthem;
    public GameObject rusAnthem;
    public GameObject drawAnthem;
    public int rusButtonCount;
    public int ameButtonCount;
    public bool gameoveryeh;
    public GameObject muricawin;
    public GameObject ruskieswin;
    public GameObject drawPaper;
    public Text rusNumber;
    public Text murNumber;
    public Text countdown;
    public GameObject afterGameButtons;
    public GameObject startBoundaries;
    public bool gameStart;
    public SecondTimer levelTimer;
    public Background_Music bg;
    public bool draw;

    private float startTime;
    private All_Screens_Manager pause;

    void Awake()
    {
        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
        drawPaper.SetActive(false);
        drawAnthem.SetActive(false);
        afterGameButtons.SetActive(false);

        pause = FindObjectOfType<All_Screens_Manager>();
        startTime = Time.time;
        gameStart = true;
    }
	
	void Update () {

        if (pause.paused)
            return;

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
            pause.startGame = false;
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
        else if(levelTimer.roundTime <= 0)
        {
            draw = true;
            drawPaper.SetActive(true);
            drawAnthem.SetActive(true);
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
}
