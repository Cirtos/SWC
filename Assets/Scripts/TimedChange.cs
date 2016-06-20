using UnityEngine;
using System.Collections;

public class TimedChange : MonoBehaviour {

    IEnumerator Start()
    {
        yield return new WaitForSeconds(04f);
        Application.LoadLevel("Title");
    }
}