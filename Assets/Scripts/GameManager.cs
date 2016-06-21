using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float startDelay;
    public GameObject ameAnthem;
    public GameObject rusAnthem;
    public int rusButtonCount;
    public int ameButtonCount;
    public static GameManager instance = null;
    public bool gameoveryeh;
    public GameObject muricawin;
    public GameObject ruskieswin;
    public Text rusNumber;
    public Text murNumber;
    public GameObject afterGameButton1;
    public GameObject afterGameButton2;
    public GameObject startBoundaries;
    public bool gameStart;
    public SecondTimer levelTimer;

    private float startTime;

    void Awake()
    {
        /*if (instance == null)            
            instance = this;        
        else if (instance != this)
           // Destroy(gameObject);
        DontDestroyOnLoad(gameObject);*/

        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
        afterGameButton1.SetActive(false);
        afterGameButton2.SetActive(false);

        startTime = Time.time;
        gameStart = true;
    }
	
	void Update () {

        rusNumber.text = "0" + rusButtonCount.ToString();
        murNumber.text = "0" + ameButtonCount.ToString();

        if (rusButtonCount >= 5 || ameButtonCount >= 5)
        {
            if (rusButtonCount >= 5)
            {
                rusAnthem.SetActive(true);
                ruskieswin.SetActive(true);
                gameoveryeh = true;
            }

            else if (ameButtonCount >= 5)
            {
                ameAnthem.SetActive(true);
                muricawin.SetActive(true);
                gameoveryeh = true;
            }

            if (Input.GetButtonDown("America_Fire") || Input.GetButtonDown("Russia_Fire"))
                    Application.LoadLevel("Title");
        }

        if(gameoveryeh)
        {
            afterGameButton1.SetActive(true);
            afterGameButton2.SetActive(true);
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
