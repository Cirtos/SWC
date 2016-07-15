using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb;
    private EmuProjectile hitEmu;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * moveSpeed;
        if(hitEmu != null)
        {
            hitEmu.Damage();
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Emu")
        {
            GameObject emu = col.gameObject;
            hitEmu = emu.GetComponent<EmuProjectile>();
        }

        if(col.gameObject.tag == "EmuPlayer")
        {
            //damage player
        }
    }
}
