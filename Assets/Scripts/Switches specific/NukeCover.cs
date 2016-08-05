using UnityEngine;
using System.Collections;

public class NukeCover : MonoBehaviour {

    public bool isRussia;
    public AudioClip flip;

    private SwitchesGameManager gManager;
    private Animator anim;
    private AudioSource audi;
    private bool hasPlayed;

	// Use this for initialization
	void Start () {
        gManager = FindObjectOfType<SwitchesGameManager>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isRussia)
        {
            if (gManager.rusSwitches == 6)
            {
                anim.SetBool("rusNuke", true);
                if (!hasPlayed)
                {
                    audi.PlayOneShot(flip, 1f);
                    hasPlayed = true;
                }
            }
            else if (gManager.rusSwitches != 6)
            {
                anim.SetBool("rusNuke", false);
                hasPlayed = false;
            }
        }
        else
        {
            if (gManager.ameSwitches == 6)
            {
                anim.SetBool("ameNuke", true);
                if (!hasPlayed)
                {
                    audi.PlayOneShot(flip, 1f);
                    hasPlayed = true;
                }
            }
            else if (gManager.ameSwitches != 6)
            {
                anim.SetBool("ameNuke", false);
                hasPlayed = false;
            }
        }
	}
}
