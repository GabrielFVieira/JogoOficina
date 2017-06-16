using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSeguePlayer : MonoBehaviour
{
    public GameObject player;
    public float velocidadeMov;
    public int controleCima;
    public int controleBaixo;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");

        velocidadeMov = 2.5f;

        controleCima = controleBaixo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.y >= -3.25f && controleBaixo == 1)
        {

            transform.Translate(0, -velocidadeMov * Time.deltaTime, 0);
        }

        if (transform.position.y <= -0.7f && controleCima == 1)
        {
            transform.Translate(0, velocidadeMov * Time.deltaTime, 0);

        }

    }

    public void AndarCima(int andarCima)
    {
        controleCima = andarCima;
    }

    public void AndarBaixo(int andarBaixo)
    {
        controleBaixo = andarBaixo;
    }
}
