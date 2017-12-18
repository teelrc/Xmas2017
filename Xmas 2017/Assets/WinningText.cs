using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningText : MonoBehaviour {

    public static WinningText instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayWinningText()
    {
        Text winniningText = GetComponent<Text>();
        if (winniningText)
        {
            winniningText.text = "You saved Christmas!!!";
        }
    }
}
