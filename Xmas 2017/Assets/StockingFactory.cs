using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockingFactory : MonoBehaviour {

	public GameObject StockingPrefab;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateStocking()
    {
       Instantiate(StockingPrefab, transform);
    }
}
