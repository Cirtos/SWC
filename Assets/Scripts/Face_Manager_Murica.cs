using UnityEngine;
using System.Collections;

public class Face_Manager_Murica : MonoBehaviour {


    public GameManager gmanager;
    private Animator anim;

    void Awake()
    {
        gmanager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        anim.SetInteger("face", gmanager.rusButtonCount);
    }


}