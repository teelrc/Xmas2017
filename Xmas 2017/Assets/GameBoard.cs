﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static GameBoard instance = null;

    private Stocking.StockingColors[] GoalSlot = new Stocking.StockingColors[4];
    private int[] GoalDict = new int[(int)Stocking.StockingColors.NumberOfTypes];
    public GameObject[] Slots = new GameObject[4];


    public int NumCorrectColors, NumCorrectColorsAndSlots;

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
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetGame()
    {
        for (int i = 0; i < GoalSlot.Length; ++i)
        {
            int val = Random.Range(0, (int)Stocking.StockingColors.NumberOfTypes);
            GoalSlot[i] = (Stocking.StockingColors)val;
            GoalDict[val] += 1;
        }
    }

    public void UpdateScore()
    {
        int numColors = 0, numColorsAndSlots = 0;

        int[] currDict = new int[(int)Stocking.StockingColors.NumberOfTypes];
        for (int i = 0; i < GoalSlot.Length; ++i)
        {
            Stocking stocking = Slots[i].GetComponentInChildren<Stocking>();
            if (stocking)
            {
                currDict[(int) stocking.stockingColor] += 1;
                if (stocking.stockingColor == GoalSlot[i])
                {
                    numColorsAndSlots += 1;
                }
            }
        }

        for (int i = 0; i < currDict.Length; ++i)
        {
            numColors += Mathf.Min(currDict[i], GoalDict[i]);
        }

        NumCorrectColors = numColors;
        NumCorrectColorsAndSlots = numColorsAndSlots;

        Debug.Log("_______________________________________________");
        Debug.Log("numColors: " + numColors);
        Debug.Log("numColorsAndSlots: " + NumCorrectColorsAndSlots);
        Debug.Log("-----------------------------------------------");


        CheckWin();

    }

    void CheckWin()
    {
        if (NumCorrectColorsAndSlots == GoalSlot.Length)
        {
            Debug.Log("YOU WIN!");
        }
    }
}
