using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadeMov;
    public int controleCima;
    public int controleBaixo;

    // Use this for initialization
    void Start()
    {
        velocidadeMov = 2.5f;

        controleCima = controleBaixo = 0;
    }

    // Update is called once per frame


    public void AndarCima(int andarCima)
    {
        controleCima = andarCima;
    }

    public void AndarBaixo(int andarBaixo)
    {
        controleBaixo = andarBaixo;
    }


    void Update()
    {

        if (transform.position.y >= 0.33f && controleBaixo != 0)
        {
            transform.Translate(0, -velocidadeMov * Time.deltaTime, 0);
        }

        if (transform.position.y <= -2.22f && controleCima != 0)
        {
            transform.Translate(0, velocidadeMov * Time.deltaTime, 0);
        }

    }
}
