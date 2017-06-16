using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {
    public EnemyHealth health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health.curHealth <= 0)
        {
            transform.localScale = new Vector3(0.27f, 7, 0);
        }
	}
}
