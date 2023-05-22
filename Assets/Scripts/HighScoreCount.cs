using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreCount : MonoBehaviour
{
    public TMP_Text highscoretext;
    public TMP_Text scoreText;
    float score;
    int highscore;

    string HS_Key = "score";

    // Use this for initialization
    void Start()
    {
        score = 0;
        highscore = -1;  

        if (PlayerPrefs.HasKey(HS_Key) == true)
        {
            highscore = PlayerPrefs.GetInt(HS_Key);
            Debug.Log("HIGHSCORE " + highscore);
            highscoretext.text = highscore.ToString();
        }
        else
        {
            PlayerPrefs.SetInt(HS_Key, highscore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //score += Time.deltaTime * 5;
        //highscore = (int)score;
        //scoreText.text = highscore.ToString();
        //if (PlayerPrefs.GetInt("score") <= highscore)
        //    PlayerPrefs.SetInt("score", highscore);
        //highscoretext.text = PlayerPrefs.GetInt("score").ToString();


        score += Time.deltaTime * 5;
        scoreText.text = " " + (int)score;
        
        if (score >= highscore)
        {
            highscore = (int)score;
            //SaveVales();
            highscoretext.text = highscore.ToString();
            
        }

    }

    private void OnDisable()
    {
        SaveVales();
    }

    private void SaveVales()
    {
        PlayerPrefs.SetInt(HS_Key, highscore);
        PlayerPrefs.Save();
    }

    //public void highscorefun()
    //{
    //    highscoretext.text= PlayerPrefs.GetInt("score").ToString();
    //}

    public void OnDelete()
    {
        PlayerPrefs.DeleteAll();
    }

}
