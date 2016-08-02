using UnityEngine;
using System.Collections;

public class Mode_Screen_Manager : MonoBehaviour {

    public GameObject argyBargy;
    public GameObject switches;
    public GameObject buttons;
    public GameObject emus;

    private Mode_Confirm mode;

	// Use this for initialization
	void Start () {
        mode = FindObjectOfType<Mode_Confirm>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(mode.levelToLoad == "Main")
        {
            buttons.SetActive(true);
            switches.SetActive(false);
            argyBargy.SetActive(false);
            emus.SetActive(false);
        }
        if (mode.levelToLoad == "Main2")
        {
            buttons.SetActive(false);
            switches.SetActive(true);
            argyBargy.SetActive(false);
            emus.SetActive(false);
        }
        if (mode.levelToLoad == "Main3")
        {
            buttons.SetActive(false);
            switches.SetActive(false);
            argyBargy.SetActive(true);
            emus.SetActive(false);
        }
        if (mode.levelToLoad == "Main4")
        {
            buttons.SetActive(false);
            switches.SetActive(false);
            argyBargy.SetActive(false);
            emus.SetActive(true);
        }
    }
}
