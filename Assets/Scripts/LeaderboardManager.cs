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
    public string[,] LoadScore()
    {
        if (File.Exists("leaderboard.txt"))
        {
            string[] rows = File.ReadAllLines("leaderboard.txt");
            string[,] scores = new string[rows.Length,2];
            
            for (int i = 0; i < rows.Length; i++)
            {
                string[] row = rows[i].Split(';');
                scores[i,0] = row[0];
                scores[i, 1] = row[1];
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
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string specificFolder = Path.Combine(folder, "Wizard in the forest");
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
       int score =  PlayerPrefs.GetInt("score");
        string playerName = PlayerPrefs.GetString("username");
        SaveScores(playerName, score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
