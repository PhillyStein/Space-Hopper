using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperOld : MonoBehaviour
{
    public static ScoreKeeperOld instance;

    public int highScore,
                startLevel;

    public bool isTutorial = true,
                isFromPause = false;

    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
