using UnityEngine;
using System.Collections;

public class Menu_Change : MonoBehaviour {

    IEnumerator Start()
    {
        yield return new WaitForSeconds(15f);
        Application.LoadLevel("Main");
    }
}