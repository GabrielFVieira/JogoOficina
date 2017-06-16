using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWater : MonoBehaviour {
	public float maxWater;
	public float curWater;
	public GameObject waterBar;
	// Use this for initialization
	void Start () {
		maxWater = 100;
		curWater = 0;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void FixedUpdate()
	{
		if (curWater > 100)
			curWater = 100;

		if (curWater >= 0)
		{
			float calc_Water = curWater / maxWater;
			SetWaterBar(calc_Water);
		}


	}

	void SetWaterBar(float myWater)
	{
		waterBar.transform.localScale = new Vector3(myWater, waterBar.transform.localScale.y, waterBar.transform.localScale.z);
	}
}
