using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private int highScore;
    private float fadeSpeed = 0.5f;
    public Text scoreText;

    public bool canControl;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        highScore = PlayerPrefs.GetInt("highscore");

        scoreText.text = "High score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.T) && canControl)
        {
            LoadGame(0);
        }

        if (Input.GetKeyUp(KeyCode.D) && canControl)
        {
            LoadGame(777);
        }

        if (Input.GetKeyUp(KeyCode.P) && canControl)
        {
            LoadGame(492);
        }

        if (Input.GetKeyUp(KeyCode.Space) && canControl)
        {
            LoadGame(1258);
        }

        if (Input.GetKeyUp(KeyCode.Q) && canControl)
        {
            Application.Quit();
        }


    }

    public void LoadGame(int startChar)
    {
        //ScoreKeeper.instance.startChar = startChar;
        PlayerPrefs.SetInt("startChar", startChar);
        SceneManager.LoadScene("Scene1");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}