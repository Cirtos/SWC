using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SecondTimer : MonoBehaviour {

    public float roundTime;
    
    private string textTime;
    private GameManager gmanager;
    private Text uiText;
    private float minutes;
    private float seconds;
    private float fraction;
    private bool rolling;

    // Use this for initialization
    void Start () {
        uiText = GetComponent<Text>();
        gmanager = FindObjectOfType<GameManager>();
	}

    void Update()
    {
        if (rolling)
            roundTime -= Time.deltaTime;
        minutes = 0;
        seconds = roundTime % 60;
        fraction = (roundTime * 100) % 100;
        textTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        uiText.text = textTime;
        if (gmanager.ameButtonCount == 5 || gmanager.rusButtonCount == 5)
            rolling = false;
        if (roundTime < 0)
        {
            rolling = false;
            roundTime = 0;
            //Draw screen reference
        }
    }
    public void GameStart()
    {
        //set up this way to only fire once
        // should also fix expire timer
        rolling = true;
    }
}
