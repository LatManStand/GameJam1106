using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoController : MonoBehaviour
{
    public float maxVelocidad;
    public float aceleracion = 2f;

    public GameObject punto1;
    public GameObject punto2;
    public GameObject punto3;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    private Rigidbody2D rb3;

    [SerializeField] private int puntoQueRota;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().simulated = true;
        rb1 = punto1.AddComponent<Rigidbody2D>();
        rb1.simulated = true;
        rb2 = punto2.AddComponent<Rigidbody2D>();
        rb2.simulated = false;
        rb3 = punto3.AddComponent<Rigidbody2D>();
        rb3.simulated = false;
        puntoQueRota = 1;
    }


    void Update()
    {
        QuePuntoRota();
        Rotar();
    }

    private void QuePuntoRota()
    {
        if (punto1.transform.position.y < punto2.transform.position.y -0.2 && punto1.transform.position.y < punto3.transform.position.y - 0.2)
        {
            punto1.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 2)
            {
                punto2.transform.SetParent(transform.GetChild(0));
                rb2.simulated = false;
            }
            else if (puntoQueRota == 3)
            {
                punto3.transform.SetParent(transform.GetChild(0));
                rb3.simulated = false;
            }

            transform.SetParent(punto1.transform);
            puntoQueRota = 1;
            rb1.simulated = true;
        }
        else if (punto3.transform.position.y < punto2.transform.position.y - 0.2 && punto3.transform.position.y < punto1.transform.position.y - 0.2)
        {
            punto3.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 2)
            {
                punto2.transform.SetParent(transform.GetChild(0));
                rb2.simulated = false;
            }
            else if (puntoQueRota == 1)
            {
                punto1.transform.SetParent(transform.GetChild(0));
                rb1.simulated = false;
            }

            transform.SetParent(punto3.transform);
            puntoQueRota = 3;
            rb3.simulated = true;
        }
        else if (false)
        {
            punto2.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 1)
            {
                punto1.transform.SetParent(transform.GetChild(0));
                rb1.simulated = false;
            }
            else if (puntoQueRota == 3)
            {
                punto3.transform.SetParent(transform.GetChild(0));
                rb3.simulated = false;
            }

            transform.SetParent(punto2.transform);
            puntoQueRota = 2;
            rb2.simulated = true;
        }
    }

    private void Rotar()
    {

        if (Input.GetKey(KeyCode.D))
        {
            if (puntoQueRota == 1)
            {
                rb1.angularVelocity -= aceleracion * Time.deltaTime;
            }
            else if (puntoQueRota == 2)
            {
                rb2.angularVelocity -= aceleracion * Time.deltaTime;
            }
            else
            {
                rb3.angularVelocity -= aceleracion * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (puntoQueRota == 1)
            {
                rb1.angularVelocity += aceleracion * Time.deltaTime;
            }
            else if (puntoQueRota == 2)
            {
                rb2.angularVelocity += aceleracion * Time.deltaTime;
            }
            else
            {
                rb3.angularVelocity += aceleracion * Time.deltaTime;
            }
        }
        if (puntoQueRota == 1)
        {
            rb1.angularVelocity = Mathf.Clamp(rb1.angularVelocity, -maxVelocidad, maxVelocidad);
        }
        else if (puntoQueRota == 2)
        {
            rb2.angularVelocity = Mathf.Clamp(rb2.angularVelocity, -maxVelocidad, maxVelocidad);
        }
        else
        {
            rb3.angularVelocity = Mathf.Clamp(rb3.angularVelocity, -maxVelocidad, maxVelocidad);
        }

    }
}
