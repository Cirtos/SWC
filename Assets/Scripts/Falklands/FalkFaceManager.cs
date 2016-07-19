using UnityEngine;
using System.Collections;

public class FalkFaceManager : MonoBehaviour {

    public FalkGameManager gmanager;
    private Animator anim;

    void Awake()
    {
        gmanager = FindObjectOfType <FalkGameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("gbrWin", gmanager.gbrWin);
        anim.SetBool("argWin", gmanager.argWin);
        anim.SetBool("draw", gmanager.draw);
    }
}
