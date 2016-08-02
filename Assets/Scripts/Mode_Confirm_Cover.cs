using UnityEngine;
using System.Collections;

public class Mode_Confirm_Cover : MonoBehaviour {

    private Mode_Confirm conf;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        conf = FindObjectOfType<Mode_Confirm>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (conf.levelToLoad != "")
        {
                anim.SetBool("active", true);
        }
        else
        {
                anim.SetBool("active", false);
        }
    }
}
