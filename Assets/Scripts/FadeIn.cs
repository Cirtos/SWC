using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{

    public float duration = 5.0f;

    private float minimum = 0.0f;
    private float maximum = 1f;
    private float startTime;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startTime = Time.time;
    }
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }
}
