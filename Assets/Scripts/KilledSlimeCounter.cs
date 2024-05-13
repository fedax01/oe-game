using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KilledSlimeCounter : MonoBehaviour
{
    
    private int counter = 0;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void CountSlimes()
    {
        counter++;
        PlayerPrefs.SetInt("score", counter);
        text.text = "Points: "+ counter.ToString();
    }
}
