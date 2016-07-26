using UnityEngine;
using System.Collections;

public class EmuFaceManager : MonoBehaviour {

    private Animator anim;
    private EmuGameManager gManager;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        gManager = FindObjectOfType<EmuGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("emuWin", gManager.emuWin);
        anim.SetBool("ausWin", gManager.ausWin);
        anim.SetBool("draw", gManager.draw);
	}
}
