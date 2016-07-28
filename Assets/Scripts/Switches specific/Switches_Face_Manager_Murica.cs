using UnityEngine;
using System.Collections;

public class Switches_Face_Manager_Murica : MonoBehaviour {


    public SwitchesGameManager gmanager;
    private Animator anim;

    void Awake()
    {
        gmanager = FindObjectOfType<SwitchesGameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("face", gmanager.ameSwitches);
        anim.SetBool("nuke", gmanager.ameNuke);
        anim.SetBool("win", gmanager.rusNuke);
        anim.SetBool("draw", gmanager.draw);
    }
}