using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static GameScore instance = null;

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

    public void SetScore(int correct, int color)
    {
        Text scoreboard = GetComponent<Text>();
        if (scoreboard)
        {
            scoreboard.text = "Number Correct " + correct + "\nNumber Colors Correct " + color;
        }
        
    }
}
