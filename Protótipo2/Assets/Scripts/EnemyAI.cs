using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public float moveSpeed;
	public float moveSpeedY;
	public float rotationSpeed;
	public float maxDistance = 12f;
	public float minDistance;
    Animator animo;
    public GameObject healthBarContainer;
    public EnemyHealth enemyHealth;

    private Transform myTransform;


	void Awake() {
		myTransform = transform;

	}
	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();


		moveSpeed = 5f;
		moveSpeedY = 1f;
		rotationSpeed = 2;
		minDistance = 0.7f;
		healthBarContainer.transform.localEulerAngles = new Vector3(0, 0, 0);
        animo = GetComponent<Animator>();

		target = GameObject.Find("Player").transform; 
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);
        if (enemyHealth.curHealth > 0)
        {
            //Look at target
            if (target.position.x < myTransform.position.x)
            {

                transform.localEulerAngles = new Vector3(0, 180, 0);
                healthBarContainer.transform.localEulerAngles = new Vector3(0, 180, 0);

            }

            if (target.position.x > myTransform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                healthBarContainer.transform.localEulerAngles = new Vector3(0, 0, 0);
            }


            if (target.position.x + maxDistance > myTransform.position.x && enemyHealth.encostando == false)
            {

                if (target.position.x + minDistance < myTransform.position.x)
                {
                    //Move towards target X
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }

                if (target.position.y > myTransform.position.y && myTransform.position.y < 2.1f && myTransform.position.x + maxDistance > target.position.x)
                {
                    //Move towards target Y
                    transform.Translate(0, moveSpeedY * Time.deltaTime, 0);
                    animo.SetInteger("Condição", 1);
                }
            }
            else
                animo.SetInteger("Condição", 0);

            if (target.position.x - maxDistance < myTransform.position.x && enemyHealth.encostando == false)
            {
                if (target.position.x - minDistance > myTransform.position.x)
                {
                    //Move towards target X
                    transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }


                if (target.position.y < myTransform.position.y && target.position.x + maxDistance > myTransform.position.x)
                {
                    //Move towards target Y
                    transform.Translate(0, moveSpeedY * Time.deltaTime * -1, 0);
                    animo.SetInteger("Condição", 1);
                }
            }
            else
                animo.SetInteger("Condição", 0);
        }
    }
}
