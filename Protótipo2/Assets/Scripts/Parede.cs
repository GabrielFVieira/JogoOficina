using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parede : MonoBehaviour {

    public GameObject Enemy;
    public GameObject parede2;
    public GameObject Jogador;
    public bool waveStart = false;
    public Camera cam;

    public int i = 0;

    public GameObject go;
	// Use this for initialization
	void Start () {
        Jogador = GameObject.Find("Player");

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        parede2 = GameObject.Find("ParedeInvisivelDireita"+cam.i);
        Enemy = GameObject.Find("Enemies"+cam.i);

        Enemy.SetActive(false);

        go = GameObject.Find("Go");
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update() {



        if (Jogador.transform.position.x > transform.position.x && Enemy.transform.childCount > 0)
        {
            waveStart = true;
        }
        if (Jogador.transform.position.x < transform.position.x)
        {
            waveStart = false;
        }
        if (waveStart == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            parede2.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        { 
            GetComponent<BoxCollider2D>().isTrigger = true;
            parede2.GetComponent<BoxCollider2D>().isTrigger = true;
        }


        if (Enemy.transform.childCount == 0)
        {
            InvokeRepeating("Go", 0.0f, 5000f);
            GetComponent<BoxCollider2D>().isTrigger = true;
            parede2.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (i > 80)
        {
            CancelInvoke();
            go.SetActive(false);
        }
    }

    void Go()
    {
        go.SetActive(true);
        i++;
    }

   // public void OnTriggerExit(Collider other)
   // {
    //    waveStart = true;
   // }
}
