using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject managerPrefab;

	// Use this for initialization
	void Start () {
        Instantiate(managerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
