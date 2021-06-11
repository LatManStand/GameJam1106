using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoController : MonoBehaviour
{
    public float maxVelocidad;
    public float momentoAngular;
    public float aceleracion = 2f;

    public GameObject punto1;
    public GameObject punto2;
    public GameObject punto3;

    [SerializeField] private int puntoQueRota;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = Instantiate(GetComponent<Rigidbody2D>(), punto1.transform);
        Destroy(GetComponent<Rigidbody2D>());
        puntoQueRota = 1;
    }


    void Update()
    {
        QuePuntoRota();
        Rotar();
    }

    private void QuePuntoRota()
    {
        if (punto1.transform.position.y < punto2.transform.position.y && punto1.transform.position.y < punto3.transform.position.y)
        {
            Rigidbody2D aux = Instantiate(rb2d, punto1.transform);
            Destroy(rb2d);
            rb2d = aux;

            punto1.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 2)
            {
                punto2.transform.SetParent(transform.GetChild(0));
            }
            else if (puntoQueRota == 3)
            {
                punto3.transform.SetParent(transform.GetChild(0));
            }

            transform.SetParent(punto1.transform);
            puntoQueRota = 1;
        }
        else if (punto3.transform.position.y < punto2.transform.position.y && punto3.transform.position.y < punto1.transform.position.y)
        {
            Rigidbody2D aux = Instantiate(rb2d, punto3.transform);
            Destroy(rb2d);
            rb2d = aux;

            punto3.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 2)
            {
                punto2.transform.SetParent(transform.GetChild(0));
            }
            else if (puntoQueRota == 1)
            {
                punto1.transform.SetParent(transform.GetChild(0));
            }

            transform.SetParent(punto3.transform);
            puntoQueRota = 3;
        }
        else
        {
            Rigidbody2D aux = Instantiate(rb2d, punto2.transform);
            Destroy(rb2d);
            rb2d = aux;

            punto2.transform.parent = null;
            transform.parent = null;

            if (puntoQueRota == 1)
            {
                punto1.transform.SetParent(transform.GetChild(0));
            }
            else if (puntoQueRota == 3)
            {
                punto3.transform.SetParent(transform.GetChild(0));
            }

            transform.SetParent(punto2.transform);
            puntoQueRota = 1;
        }
    }

    private void Rotar()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.angularVelocity -= aceleracion * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.angularVelocity += aceleracion * Time.deltaTime;
        }
        rb2d.angularVelocity = Mathf.Clamp(rb2d.angularVelocity, -maxVelocidad, maxVelocidad);
        momentoAngular = rb2d.angularVelocity;
    }
}
