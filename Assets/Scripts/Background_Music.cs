using UnityEngine;
using System.Collections;

public class Background_Music : MonoBehaviour {

    public AudioSource countdown;
    public AudioSource levelMusic;

    private bool gameOver;
    
	// Use this for initialization
	void Start () {
        levelMusic.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!countdown.isPlaying && !gameOver)
        {
            levelMusic.enabled = true;
        }
	}

    public void Victory()
    {
        levelMusic.enabled = false;
        countdown.enabled = false;
        gameOver = true;
    }
}
