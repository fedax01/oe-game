using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreScript : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        int score =  PlayerPrefs.GetInt("score");
        text.text = "Points: "+ score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
