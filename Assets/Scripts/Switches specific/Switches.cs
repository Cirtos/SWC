﻿using UnityEngine;
using System.Collections;

public class Switches : MonoBehaviour {

    public Sprite nukeUnprimed;
    public Sprite notPressed;
    public Sprite pressed;
    public bool isRussia;
    public bool isNuke;

    private bool press;
    private bool primed;
    private SpriteRenderer sprite;
    private SwitchesGameManager gManager;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        gManager = FindObjectOfType<SwitchesGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isNuke)
        {
            if (isRussia)
            {
                if (gManager.rusSwitches == 6)
                {
                    primed = true;
                    sprite.sprite = notPressed;
                }
                else
                {
                    primed = false;
                    sprite.sprite = nukeUnprimed;
                }
            }
            if (!isRussia)
            {
                if (gManager.ameSwitches == 6)
                {
                    primed = true;
                    sprite.sprite = notPressed;
                }
                else
                {
                    primed = false;
                    sprite.sprite = nukeUnprimed;
                }
            }
        }

    }

    public void Pressed()
    {
        if (isNuke)
        {
            NukePress();
            return;
        }
        if (!press)
        {
            sprite.sprite = pressed;
            press = true;
            if (isRussia)
                gManager.rusSwitches++;
            else
                gManager.ameSwitches++;
        }
        else
        {
            sprite.sprite = notPressed;
            press = false;
            if (isRussia)
                gManager.rusSwitches--;
            else
                gManager.ameSwitches--;
        }
    }

    public void NukePress()
    {
        if (isRussia)
        {
            if (gManager.rusSwitches == 6)
            {
                gManager.NukePressed("Russia");
            }
        }
        if (!isRussia)
        {
            if (gManager.ameSwitches == 6)
            {
                gManager.NukePressed("America");
            }
        }
    }
}
