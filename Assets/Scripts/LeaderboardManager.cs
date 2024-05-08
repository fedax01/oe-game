using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public bool autoSave;
    public bool autoPrint;
    string specificFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wizard in the forest");
    public string[,] LoadScore()
    {
        string leaderboardTxt = Path.Combine(specificFolder, "leaderboard.txt");
        if (File.Exists(leaderboardTxt))
        {
            string[] rows = File.ReadAllLines(leaderboardTxt);
            string[,] scores = new string[rows.Length,2];
            
            for (int i = 0; i < rows.Length; i++)
            {
                string[] row = rows[i].Split(';');
                if (row.Length == 2)
                {
                    scores[i, 0] = row[0];
                    scores[i, 1] = row[1];
                }
                else
                {
                    scores[i, 0] = "";
                    scores[i, 1] = "0";
                }
                
            }
            return scores;
        }
        string[,] empty = new string[1, 2] { {"","0"} };
        return empty;
        
    } 
    public bool SaveScores(string name, int scores)
    {
        string[,] currentScores = LoadScore();
        string[,] newScores = new string[currentScores.GetLength(0) + 1, 2];
        int db = 0;
        if (scores > int.Parse(currentScores[0,1]))
        {
            newScores[db, 0] = name;
            newScores[db, 1] = scores.ToString();
            db++;
        }

        for(int i = 0;i < currentScores.GetLength(0) -1 ; i++)
        {
            newScores[db, 0] = currentScores[i, 0];
            newScores[db, 1] = currentScores[i, 1];
            db++;

           
            if (int.Parse(currentScores[i,1]) > scores && int.Parse(currentScores[i + 1, 1]) <= scores)
            {
                newScores[db, 0] = name;
                newScores[db, 1] = scores.ToString();
                db++;
            }

        }
        newScores[db, 0] = currentScores[currentScores.GetLength(0) - 1, 0];
        newScores[db, 1] = currentScores[currentScores.GetLength(0) - 1, 1];
        db++;
        if (scores < int.Parse(currentScores[currentScores.GetLength(0)-1, 1]))
        {
            newScores[db,0] = name;
            newScores[db, 1] = scores.ToString();
            db++;
        }
        string filerows = "";
        for (int i = 0; i < newScores.GetLength(0); i++)
        {
            filerows += newScores[i, 0] + ";" + newScores[i,1] + "\n";
        }
       
        print(specificFolder);
        if (Directory.Exists(specificFolder) == false)
        {
            Directory.CreateDirectory(specificFolder);
        }
        string filename = Path.Combine(specificFolder, "leaderboard.txt");
        File.WriteAllText(filename, filerows);

        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (autoSave == true)
        {
            int score = PlayerPrefs.GetInt("score");
            string playerName = PlayerPrefs.GetString("username");
            SaveScores(playerName, score);
        }
        if (autoPrint == true)
        {
            PrintLeaderBoard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PrintLeaderBoard()
    {
        string[,] leaderboard = LoadScore();
        Text text = gameObject.GetComponent<Text>();
        text.text = string.Empty;
        for (int i = 0;i < leaderboard.GetLength(0);i++)
        {
            text.text += leaderboard[i,0];
            text.text += " ";
            text.text += leaderboard[i, 1];
            text.text+= "\n";
            
        }
    }
}
