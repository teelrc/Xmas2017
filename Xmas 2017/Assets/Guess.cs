using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guess : MonoBehaviour {


    public GameObject[] slots = new GameObject[4];
    public int NumCorrectColors, NumCorrectColorsAndSlots;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGuess()
    {
        NumCorrectColors = GameBoard.instance.NumCorrectColors;
        NumCorrectColorsAndSlots = GameBoard.instance.NumCorrectColorsAndSlots;

        for (int i=0; i<slots.Length; i++)
        {
            Transform slotChild = GameBoard.instance.Slots[i].transform.GetChild(0);
            if (slotChild)
            {
                slots[i] = Instantiate(slotChild.gameObject,slots[i].transform.position, Quaternion.identity ,transform);
                slots[i].transform.localScale = slotChild.lossyScale;
                slots[i].GetComponent<Collider2D>().enabled = false;
                foreach (MonoBehaviour script in slots[i].GetComponents<MonoBehaviour>())
                {
                    if (script.GetType() != typeof(SpriteRenderer))
                    {
                        script.enabled = false;
                    }
                }
            }
        }

        Text t = GetComponentInChildren<Text>();
        t.text = NumCorrectColors + " " + NumCorrectColorsAndSlots; 
      
    }

    

}
