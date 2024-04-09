using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public GameObject heart;
    private List<GameObject> hearts = new List<GameObject>();
    private int life = 5;
    private int prevLife = 5;
    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 1; i < life; i++)
        {
            AddHeart(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (life < prevLife) 
        {
            int lifeDifference = prevLife - life;
            for (int i = 0; i < lifeDifference; i++)
            {
                DestroyHeart();
            }

        }
        else if (life > prevLife) 
        {
            int lifeDifference = life - prevLife;
            for (int i = 0; i < lifeDifference; i++) 
            {
                AddHeart(hearts.Count);
            }
        }
    }
    public void AddHeart(int i)
    {
        GameObject newHeart = Instantiate(heart);
        newHeart.transform.position += new Vector3(0.5f * i, 0, 0);
        hearts.Add(newHeart);
    }
    public void DestroyHeart()
    {
        GameObject heart = hearts[hearts.Count-1];
        Destroy(heart);
    }
}
