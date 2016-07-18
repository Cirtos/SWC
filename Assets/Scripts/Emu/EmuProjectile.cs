using UnityEngine;
using System.Collections;

public class EmuProjectile : MonoBehaviour {

    public float moveSpeed;

    private EmuGameManager gManager;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        gManager = FindObjectOfType<EmuGameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = -transform.right * moveSpeed;
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Tank Zone")
        {
            gManager.emusZoned++;
            Destroy(gameObject);
        }
    }
}
