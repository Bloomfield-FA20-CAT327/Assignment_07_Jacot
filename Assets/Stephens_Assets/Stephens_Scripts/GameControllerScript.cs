
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    Text uiText;

    public int strength;

    public int speed;

    public int intelligence;

    public int score;

    public int playingLevel;


    void Awake()
    {
      if(PlayerPrefs.HasKey("intelligence"))
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
        
        uiText = GameObject.Find("StatsText").GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        string UItextinfo = "";

        UItextinfo += "Score : " + score + "\n";
        UItextinfo += "Strength: " + strength + "\n";
        UItextinfo += "Speed: " + speed + "\n";
        UItextinfo += "Intelligence: " + intelligence + "\n";

        uiText.text = UItextinfo;
    }

    public void NewGame()
    {
        if(PlayerPrefs.HasKey("intelligence"))
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

    private void LoadStage()
    {
        PlayerStatsSetter();
        SceneManager.LoadScene(playingLevel);
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
        playingLevel = PlayerPrefs.GetInt("playinglevel");

    }

    void GetRidOfPlayerValues()
    {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("intelligence");
        PlayerPrefs.DeleteKey("strength");
        PlayerPrefs.DeleteKey("speed");

    }

    public void StrengthAdd()
    {
        strength += 5;
    }

    public void IntelliAdd()
    {
        intelligence += 5;
    }

    public void SpeedAdd()
    {
        speed += 5;
    }

    public void UpLevel()
    {
        playingLevel = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene();
    }

    private void LoadScene()
    {
        PlayerStatsSetter();
        SceneManager.LoadScene(playingLevel);
    }
}
