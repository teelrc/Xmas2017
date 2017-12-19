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
            scoreboard.text = "<color=#000000ff>Number Correct: " + correct +
                "</color><color=#c0c0c0ff>\nNumber Correct Colors: " + color + "</color>";
        }
        
    }
}
