using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public int strength;

    public int speed;

    public int intelligence;

    public int score;

    public int playingLevel;


    void Awake()
    {
      if(PlayerPrefs.HasKey("score"))
        {
            GetPlayerStats();
            if(playingLevel!=0&&playingLevel!=SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(playingLevel);
            }
        }
      else
        {
            NewGame();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        if(PlayerPrefs.HasKey("score"))
        {
            GetRidOfPlayerValues();
        }

        score = 0;
        strength = 0;
        intelligence = 0;
        speed = 0;
        playingLevel = 0;

        if(SceneManager.GetActiveScene().buildIndex!=0)
        {
            SceneManager.LoadScene(0);
        }
        PlayerStatsSetter();
    }

    void PlayerStatsSetter()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("intelligence", intelligence);
        PlayerPrefs.SetInt("strength", strength);
        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.Save();
    }

    void GetPlayerStats()
    {
        score = PlayerPrefs.GetInt("score");
        intelligence = PlayerPrefs.GetInt("intelligence");
        strength = PlayerPrefs.GetInt("strength");
        speed = PlayerPrefs.GetInt("speed");

    }

    void GetRidOfPlayerValues()
    {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("intelligence");
        PlayerPrefs.DeleteKey("strength");
        PlayerPrefs.DeleteKey("speed");

    }
}
