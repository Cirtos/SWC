using UnityEngine;
using System.Collections;

public class NukeCover : MonoBehaviour {

    public bool isRussia;

    private SwitchesGameManager gManager;
    private Animator anim;

	// Use this for initialization
	void Start () {
        gManager = FindObjectOfType<SwitchesGameManager>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isRussia)
        {
            if (gManager.rusSwitches == 6)
            {
                anim.SetBool("rusNuke", true);
            }
            else if (gManager.rusSwitches != 6)
            {
                anim.SetBool("rusNuke", false);
            }
        }
        else
        {
            if (gManager.ameSwitches == 6)
            {
                anim.SetBool("ameNuke", true);
            }
            else if (gManager.ameSwitches != 6)
            {
                anim.SetBool("ameNuke", false);
            }
        }
	}
}
