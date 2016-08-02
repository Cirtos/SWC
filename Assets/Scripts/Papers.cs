using UnityEngine;
using System.Collections;

public class Papers : MonoBehaviour {

    private All_Screens_Manager pause;

	// Use this for initialization
	void Start () {
        pause = FindObjectOfType<All_Screens_Manager>();
        pause.endGame = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
