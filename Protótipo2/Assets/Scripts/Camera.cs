using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public Transform lookAt;
    Transform pos;
    public Parede parede;
    public GameObject waveCenter;
    public bool cameraLock = false;
    public GameObject Enemies;
    public GameObject parede1;

    public int i = 1;
    public bool controle = false;
    void Start()
    {
        parede = GameObject.Find("ParedeInvisivelEsquerda"+i).GetComponent<Parede>();
        pos = lookAt.transform;
        waveCenter = GameObject.Find("WaveCenter"+i);
        Enemies = GameObject.Find("Enemies"+i);
        parede1 = GameObject.Find("ParedeInvisivelEsquerda"+i);
    }

    void Update()
    {
        transform.position = new Vector3(pos.position.x, transform.position.y, transform.position.z);

        if (parede.waveStart == true && cameraLock == true)
        {
            transform.position = new Vector3(waveCenter.transform.position.x, transform.position.y, transform.position.z);
        }

        if (pos.position.x >= waveCenter.transform.position.x && Enemies.transform.childCount > 0)
        {
            cameraLock = true;
            Enemies.SetActive(true);
        }

        if (cameraLock == true && parede1.GetComponent<BoxCollider2D>().isTrigger == false)
            controle = true;


        if (Enemies.transform.childCount == 0)// && pos.position.x >= waveCenter.transform.position.x || pos.position.x <= parede1.transform.position.x)
        {
            cameraLock = false;

            if (controle == true)
            {
                i += 1;
                controle = false;
            }
        }
    }
}