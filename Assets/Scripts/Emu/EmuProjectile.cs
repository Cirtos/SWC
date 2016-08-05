using UnityEngine;
using System.Collections;

public class EmuProjectile : MonoBehaviour {

    public float moveSpeed;
    public int scorePerEmu;
    public AudioClip[] wark;

    private EmuGameManager gManager;
    private Rigidbody2D rb;
    private Animator anim;
    private All_Screens_Manager pause;
    private AudioSource audi;

	// Use this for initialization
	void Start () {
        gManager = FindObjectOfType<EmuGameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pause = FindObjectOfType<All_Screens_Manager>();
        audi = GetComponent<AudioSource>();

        int clipToPlay = Random.Range(0, wark.Length);
        audi.PlayOneShot(wark[clipToPlay], 1f);
    }
	
	// Update is called once per frame
	void Update () {
        
        if(gManager.gameOver)
        {
            Destroy(gameObject);
        }

        if (pause.paused)
            rb.velocity = -transform.right * 0;
        else
            rb.velocity = -transform.right * moveSpeed;
    }

    public void Die ()
    {
        anim.SetBool("die", true);
        moveSpeed = 0;
    }

    void Remove ()
    {
        Destroy(gameObject);
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Tank Zone")
        {
            gManager.emusZoned += scorePerEmu;
            Destroy(gameObject);
        }
    }
}
