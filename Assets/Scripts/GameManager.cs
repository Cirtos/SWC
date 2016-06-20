using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject ameAnthem;
    public GameObject rusAnthem;
    public int rusButtonCount;
    public int ameButtonCount;
    public static GameManager instance = null;
    public bool gameoveryeh;
    public GameObject muricawin;
    public GameObject ruskieswin;

    void Awake()
    {
        if (instance == null)            
            instance = this;        
        else if (instance != this)
           // Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
    }
	
	void Update () {
	
        if (rusButtonCount >= 5 || ameButtonCount >= 5)
        {
            if (rusButtonCount >= 5)
            {
                rusAnthem.SetActive(true);
                ruskieswin.SetActive(true);
                gameoveryeh = true;
                
            }

            else if (ameButtonCount >= 5)
            {
                ameAnthem.SetActive(true);
                muricawin.SetActive(true);
                gameoveryeh = true;
            }

            if (Input.GetButtonDown("America_Fire") || Input.GetButtonDown("Russia_Fire"))
                    Application.LoadLevel("Title");
        }
    }

    void Reset()
    {
        ameButtonCount = 0;
        rusButtonCount = 0;
        ameAnthem.SetActive(false);
        rusAnthem.SetActive(false);
        gameoveryeh = false;
        ruskieswin.SetActive(false);
        muricawin.SetActive(false);
    }
}
