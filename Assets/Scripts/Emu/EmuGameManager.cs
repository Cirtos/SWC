using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmuGameManager : MonoBehaviour
{

    public float startDelay;
    public GameObject ausAnthem;
    public GameObject emuAnthem;
    public GameObject ausWin;
    public GameObject emuWin;
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

    private float startTime;

    void Awake()
    {
        ausAnthem.SetActive(false);
        emuAnthem.SetActive(false);
        ausWin.SetActive(false);
        emuWin.SetActive(false);
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
                emuWin.SetActive(true);
            }
            else if (bulletsZoned > emusZoned)
            {
                ausAnthem.SetActive(true);
                ausWin.SetActive(true);
            }
            else
            {
                //draw
            }

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