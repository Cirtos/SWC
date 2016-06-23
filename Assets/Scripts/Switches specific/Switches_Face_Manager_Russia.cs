using UnityEngine;
using System.Collections;

public class Switches_Face_Manager_Russia : MonoBehaviour
{

    public SwitchesGameManager gmanager;
    private Animator anim;

    void Awake()
    {
        gmanager = FindObjectOfType<SwitchesGameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("face", gmanager.rusSwitches);
        anim.SetBool("nuke", gmanager.rusNuke);
        anim.SetBool("win", gmanager.ameNuke);
    }
}