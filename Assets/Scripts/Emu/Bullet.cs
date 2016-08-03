using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    private EmuGameManager gManager;
    private Rigidbody2D rb;
    private EmuProjectile hitEmu;
    private All_Screens_Manager pause;

	// Use this for initialization
	void Start () {
        pause = FindObjectOfType<All_Screens_Manager>();
        gManager = FindObjectOfType<EmuGameManager>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gManager.gameOver)
        {
            Destroy(gameObject);
        }

        if (pause.paused)
            rb.velocity = transform.right * 0;
        else
            rb.velocity = transform.right * moveSpeed;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Emu")
        {
            EmuProjectile emu = col.GetComponent<EmuProjectile>();
            emu.Die();
            Destroy(col);
            gManager.bulletsZoned++;
            Destroy(gameObject);
        }

        if(col.gameObject.name == "Emu Zone")
        {
            Destroy(gameObject);
        }
    }
}
