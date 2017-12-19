using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour {

    public static History instance = null;
    public int guessCount = 0;
    public List<GameObject> guesses;
    public GameObject guess;

    public void AddGuess()
    {
        GameObject g = Instantiate(guess, guesses[guessCount].transform.position, Quaternion.identity, transform);
        g.GetComponent<Guess>().SetGuess();
        guesses[guessCount] = g;
        guessCount++;
    }

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
}
