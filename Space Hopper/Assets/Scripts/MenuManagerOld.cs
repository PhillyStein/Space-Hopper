﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerOld : MonoBehaviour
{

    private int highScore;
    private float fadeSpeed;
    public Text scoreText;

    public Image whitePanel,
                        gameJam,
                        phillyStein;

    public bool phillyFadeIn,
                    phillyFadeOut,
                    jamFadeIn,
                    jamFadeOut,
                    whiteFadeOut,
                    canControl;

    // Start is called before the first frame update
    void Start()
    {
        SkipCredits();
        highScore = ScoreKeeperOld.instance.highScore;
        scoreText.text = "High score: " + highScore;

        /*
        if (ScoreKeeper.instance.isFromPause)
        {
            SkipCredits();
        }
        else
        {
            fadeSpeed = 0.3f;

            gameJam.color = new Color(gameJam.color.r, gameJam.color.g, gameJam.color.b, 0f);
            phillyStein.color = new Color(phillyStein.color.r, phillyStein.color.g, phillyStein.color.b, 0f);

            phillyFadeIn = true;
            phillyFadeOut = false;
            jamFadeIn = false;
            jamFadeOut = false;
            whiteFadeOut = false;
            canControl = false;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.T) && canControl)
        {
            LoadGame(0);
        }

        if (Input.GetKeyUp(KeyCode.Space) && canControl)
        {
            LoadGame(5);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !canControl)
        {
            SkipCredits();
        }

        if (Input.GetKeyUp(KeyCode.Q) && canControl)
        {
            SceneManager.LoadScene("Title");
        }

        if (phillyFadeIn)
        {
            phillyStein.color = new Color(phillyStein.color.r, phillyStein.color.g, phillyStein.color.b, Mathf.MoveTowards(phillyStein.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (phillyStein.color.a == 1f)
            {
                phillyFadeIn = false;
                phillyFadeOut = true;
            }
        }

        if (phillyFadeOut)
        {
            phillyStein.color = new Color(phillyStein.color.r, phillyStein.color.g, phillyStein.color.b, Mathf.MoveTowards(phillyStein.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (phillyStein.color.a == 0f)
            {
                phillyFadeOut = false;
                jamFadeIn = true;
            }
        }
        
        if (jamFadeIn)
        {
            gameJam.color = new Color(gameJam.color.r, gameJam.color.g, gameJam.color.b, Mathf.MoveTowards(gameJam.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (gameJam.color.a == 1f)
            {
                jamFadeIn = false;
                jamFadeOut = true;
            }
        }

        if (jamFadeOut)
        {
            gameJam.color = new Color(gameJam.color.r, gameJam.color.g, gameJam.color.b, Mathf.MoveTowards(gameJam.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (gameJam.color.a == 0f)
            {
                jamFadeOut = false;
                whiteFadeOut = true;
            }
        }

        if (whiteFadeOut)
        {
            whitePanel.color = new Color(whitePanel.color.r, whitePanel.color.g, whitePanel.color.b, Mathf.MoveTowards(whitePanel.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (whitePanel.color.a == 0f)
            {
                whiteFadeOut = false;
                canControl = true;
            }
        }


    }

    public void LoadGame(int startLevel)
    {
        ScoreKeeperOld.instance.startLevel = startLevel;
        SceneManager.LoadScene("OldGame");
    }

    public void SkipCredits()
    {
        phillyStein.color = new Color(phillyStein.color.r, phillyStein.color.g, phillyStein.color.b, 0f);
        gameJam.color = new Color(gameJam.color.r, gameJam.color.g, gameJam.color.b, 0f);
        whitePanel.color = new Color(whitePanel.color.r, whitePanel.color.g, whitePanel.color.b, 0f);
        canControl = true;
        phillyFadeIn = false;
        phillyFadeOut = false;
        jamFadeIn = false;
        jamFadeOut = false;
        whiteFadeOut = false;
    }
}