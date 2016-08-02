using UnityEngine;
using System.Collections;

public class All_Screens_Manager : MonoBehaviour {

    public static All_Screens_Manager instance;
    public GameObject blueHand;
    public GameObject redHand;
    public GameObject pauseMenu;
    public bool paused;
    public bool endGame;
    public bool startGame;

    // Use this for initialization
    void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        blueHand.SetActive(false);
        redHand.SetActive(false);
        pauseMenu.SetActive(false);
	}

    void OnLevelWasLoaded()
    {
        startGame = true;
        endGame = false;
    }

	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName != "Menu" && !endGame && !startGame)
        {
            if (Input.GetKeyDown("joystick 1 button 7"))
            {
                paused = true;
                blueHand.SetActive(true);
                pauseMenu.SetActive(true);
            }
            if (Input.GetKeyDown("joystick 2 button 7"))
            {
                paused = true;
                redHand.SetActive(true);
                pauseMenu.SetActive(true);
            }
        }
	}

    public void ClearPause ()
    {
        blueHand.SetActive(false);
        redHand.SetActive(false);
        pauseMenu.SetActive(false);
        paused = false;
    }
}
