using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public GameObject popup;
    public InputField inputField;
    public  void Run()
    {
        PlayerPrefs.SetString("username",inputField.text);
        Destroy(popup);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
