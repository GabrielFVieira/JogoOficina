using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchWaterBall : MonoBehaviour {
    public PlayerWater water;
    public GameObject waterBallPrefab;
    public bool Fire;
	// Use this for initialization
	void Start () {
        water = GetComponent<PlayerWater>();
	}
	
	// Update is called once per frame
	void Update () {
		if(water.curWater > 0)
        {
            if(water.curWater >= 20 && Fire == true)
            {
                GameObject waterBall = Instantiate(waterBallPrefab) as GameObject;
                waterBall.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                if (transform.localScale.x < 0)
                {
                    waterBall.transform.localScale = new Vector3(0.7530775f, -0.7530775f, 0.7530775f);
                    waterBall.GetComponent<WaterBall>().velocity *= -1;
                }
                else
                    waterBall.GetComponent<WaterBall>().velocity = waterBall.GetComponent<WaterBall>().velocity;

                water.curWater -= 20;

                Fire = false;
            }
        }
	}

    public void AtirarAgua(bool Launch)
    {
        Fire = Launch;
    }
}
