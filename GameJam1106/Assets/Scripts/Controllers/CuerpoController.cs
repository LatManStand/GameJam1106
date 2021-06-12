using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoController : MonoBehaviour
{
    public float maxVelocidad;
    public float aceleracion;

    public float cooldownCabeza = 1f;
    public bool tengoCabeza = false;
    private GameObject cabeza;
    private float ultimaCabeza = 0f;

    public float fuerzaLanzarCabeza;

    public GameObject punto1;
    public GameObject punto2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;


    [SerializeField] private int puntoQueRota;

    private void Awake()
    {
        rb1 = punto1.GetComponent<Rigidbody2D>();
        rb2 = punto2.GetComponent<Rigidbody2D>();
        TocaElSuelo(punto2);
    }


    void Update()
    {
        if (tengoCabeza)
        {
            Rotar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LanzarCabeza();
            }
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

    private void LanzarCabeza()
    {
        tengoCabeza = false;
        cabeza.transform.SetParent(null);
        cabeza.GetComponent<CalaveraController>().enabled = true;
        cabeza.GetComponent<Rigidbody2D>().simulated = true;
        cabeza.GetComponent<Rigidbody2D>().AddForce((cabeza.transform.position - transform.position) * fuerzaLanzarCabeza);
        cabeza.layer = 11;
        ultimaCabeza = Time.timeSinceLevelLoad;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cabeza") && ultimaCabeza + cooldownCabeza < Time.timeSinceLevelLoad)
        {
            Invoke(nameof(ControllerCD), 0.3f);
            cabeza = collision.gameObject.transform.gameObject;
            cabeza.transform.SetParent(transform);
            cabeza.layer = 10;
            cabeza.GetComponent<CalaveraController>().enabled = false;
            cabeza.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            cabeza.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            cabeza.GetComponent<Rigidbody2D>().simulated = false;
            cabeza.transform.DOMove(transform.GetChild(1).position, 0.3f).Play();
            cabeza.transform.DOLocalRotate(Vector3.zero, 0.3f).Play();
        }
    }

    private void ControllerCD()
    {
        tengoCabeza = !tengoCabeza;
    }
}
