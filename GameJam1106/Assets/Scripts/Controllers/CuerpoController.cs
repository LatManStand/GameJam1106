using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoController : MonoBehaviour
{
    public float maxVelocidad;
    public float aceleracion = 2f;

    public GameObject punto1;
    public GameObject punto2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;

    [SerializeField] private int puntoQueRota;

    private void Awake()
    {
        rb1 = punto1.GetComponent<Rigidbody2D>();
        rb2 = punto2.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Rotar();
    }

    private void QuePuntoRota()
    {
        if (punto1.transform.position.y < punto2.transform.position.y - 0.2)
        {
            punto1.transform.parent = null;
            transform.parent = null;

            punto2.transform.SetParent(transform.GetChild(0));
            rb2.isKinematic = true;

            transform.SetParent(punto1.transform);
            puntoQueRota = 1;
            rb1.isKinematic = false;
        }
        else
        {
            punto2.transform.parent = null;
            transform.parent = null;

            punto1.transform.SetParent(transform.GetChild(0));
            rb1.isKinematic = true;


            transform.SetParent(punto2.transform);
            puntoQueRota = 2;
            rb2.isKinematic = false;
        }
    }

    private void Rotar()
    {
        if (puntoQueRota == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb1.angularVelocity -= aceleracion * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb1.angularVelocity += aceleracion * Time.deltaTime;
            }
            rb1.angularVelocity = Mathf.Clamp(rb1.angularVelocity, -maxVelocidad, maxVelocidad);
        }

        else if (puntoQueRota == 2)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb2.angularVelocity -= aceleracion * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb2.angularVelocity += aceleracion * Time.deltaTime;
            }
            rb2.angularVelocity = Mathf.Clamp(rb2.angularVelocity, -maxVelocidad, maxVelocidad);
        }

    }

    public void TocaElSuelo(GameObject punto)
    {
        Debug.Log("Ha tocado " + punto.name);
        if (punto == punto1)
        {
            punto1.transform.SetParent(null);
            transform.SetParent(null);

            punto2.transform.SetParent(transform.GetChild(0));
            rb2.angularVelocity = 0f;
            rb2.isKinematic = true;

            transform.SetParent(punto1.transform);
            puntoQueRota = 1;
            rb1.isKinematic = false;
        }
        else
        {
            punto2.transform.SetParent(null);
            transform.SetParent(null);

            punto1.transform.SetParent(transform.GetChild(0));
            rb1.angularVelocity = 0f;
            rb1.isKinematic = true;

            transform.SetParent(punto2.transform);
            puntoQueRota = 2;
            rb2.isKinematic = false;
        }
    }
}
