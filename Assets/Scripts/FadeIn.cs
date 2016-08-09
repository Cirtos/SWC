using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public bool disableTillFaded;
    public float duration = 5.0f;

    private float minimum = 0.0f;
    private float maximum = 1f;
    private float startTime;
    private SpriteRenderer sprite;
    private BoxCollider2D col;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        col = GetComponent<BoxCollider2D>();

        if (disableTillFaded)
            col.enabled = false;
    }
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
        if (disableTillFaded)
        {
            if(Time.time > (startTime/2))
            {
                col.enabled = true;
            }
        }
    }
}
