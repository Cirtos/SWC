using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmuGameManager : MonoBehaviour
{

    public float startDelay;
    public GameObject ausAnthem;
    public GameObject emuAnthem;
    public GameObject ausWinPaper;
    public GameObject emuWinPaper;
    public GameObject drawPaper;
    public GameObject drawAnthem;
    public int emusZoned;
    public int bulletsZoned;
    public Text emuNumber;
    public Text tankNumber;
    public Text countdown;
    public GameObject afterGameButtons;
    public SecondTimer levelTimer;
    public Background_Music bg;
    public bool gameOver;
    public bool gameNotStarted;
    public bool emuWin;
    public bool ausWin;
    public bool draw;

    private float startTime;

    void Awake()
    {
        ausAnthem.SetActive(false);
        emuAnthem.SetActive(false);
        ausWinPaper.SetActive(false);
        emuWinPaper.SetActive(false);
        drawPaper.SetActive(false);
        //drawAnthem.SetActive(false);
        afterGameButtons.SetActive(false);

        startTime = Time.time;
        gameNotStarted = true;
    }

    void Update()
    {

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
        
        emuNumber.text = emusZoned.ToString();
        tankNumber.text = bulletsZoned.ToString();

        if (levelTimer.roundTime <= 0)
        {
            if (emusZoned > bulletsZoned)
            {
                emuAnthem.SetActive(true);
                emuWinPaper.SetActive(true);
                emuWin = true;
            }
            else if (bulletsZoned > emusZoned)
            {
                ausAnthem.SetActive(true);
                ausWinPaper.SetActive(true);
                ausWin = true;
            }
            else
            {
                draw = true;
                drawPaper.SetActive(true);
                //drawAnthem.SetActive(true);
            }

            levelTimer.StopTimer();
            gameOver = true;
            bg.Victory();
            afterGameButtons.SetActive(true);
        }

        if (Time.time > (startTime + startDelay))
        {
            if (gameNotStarted)
            {
                levelTimer.GameStart();
                gameNotStarted = false;
            }
        }
    }
}