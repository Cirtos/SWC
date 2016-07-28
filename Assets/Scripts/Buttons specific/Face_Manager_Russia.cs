using UnityEngine;
using System.Collections;

public class Face_Manager_Russia : MonoBehaviour
{

    public GameManager gmanager;
    private Animator anim;

    void Awake()
    {
        gmanager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        anim.SetInteger("face", gmanager.ameButtonCount);
        anim.SetBool("draw", gmanager.draw);
    }    
}