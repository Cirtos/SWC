﻿using UnityEngine;
using System.Collections;

public class Mode_Confirm : MonoBehaviour
{
    public string levelToLoad;
    public Sprite nukeUnprimed;
    public Sprite notPressed;
    public Sprite pressed;
    public GameObject switches;
    public GameObject emus;
    public GameObject buttons;
    public GameObject argyBargy;
    public GameObject background;
    public GameObject cont;

    private bool focus;
    private string colTag;
    private SpriteRenderer sprite;
    private bool displayRules;
    private Mode_Confirm mode;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        buttons.SetActive(false);
        switches.SetActive(false);
        argyBargy.SetActive(false);            
        emus.SetActive(false);
        background.SetActive(false);
        cont.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (levelToLoad != "")
            sprite.sprite = notPressed;
        else if (levelToLoad == "")
            sprite.sprite = nukeUnprimed;

        if (displayRules)
        {
            background.SetActive(true);
            cont.SetActive(true);

            if (levelToLoad == "Main")
            {
                buttons.SetActive(true);
            }
            if (levelToLoad == "Main2")
            {
                switches.SetActive(true);
            }
            if (levelToLoad == "Main3")
            {
                argyBargy.SetActive(true);
            }
            if (levelToLoad == "Main4")
            {
                emus.SetActive(true);
            }

            if (Input.GetButtonDown("P1 Fire") || Input.GetButtonDown("P2 Fire"))
                Application.LoadLevel(levelToLoad);
        }


        if (focus == true)
        {
            if (colTag == "Russia")
            {
                if (Input.GetButtonDown("P2 Fire"))
                {
                    if (levelToLoad != "")
                    {
                        displayRules = true;
                        sprite.sprite = pressed;
                    }
                }

            }
            else if (colTag == "America")
            {
                if (Input.GetButtonDown("P1 Fire"))
                {
                    if (levelToLoad != "")
                    {
                        displayRules = true;
                        sprite.sprite = pressed;
                    }
                }
            }
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        focus = true;
        colTag = col.gameObject.tag;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        focus = false;
        colTag = "";
    }
}