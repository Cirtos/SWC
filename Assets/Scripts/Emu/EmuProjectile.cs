using UnityEngine;
using System.Collections;

public class EmuProjectile : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * moveSpeed;
    }
    public void Damage ()
    {
        //damage to emu count?
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Tank Zone")
        {
            //minus tank health
        }
    }
}
