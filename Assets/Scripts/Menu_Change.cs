using UnityEngine;
using System.Collections;

public class Menu_Change : MonoBehaviour {

    public string sceneToTrans;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(15f);
        Application.LoadLevel(sceneToTrans);
    }
}