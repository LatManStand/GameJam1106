using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerpoController : MonoBehaviour
{
    public float velocidadAndar;
    public float fuerzaSalto;
    public float maxVelocidadAngular;
    public float aceleracionAngular;

    public bool tengoCabeza = false;
    public bool tengoBrazo = false;
    public bool tengoPierna = false;

    public float cooldownCogido = 1f;
    public float ultimoCogido = 0f;

    private GameObject cabeza;
    private GameObject piernas;
    private Rigidbody2D piernasRB;
    private Animator piernasAnim;
    private GameObject brazo;

    private GroundCheck groundCheck;

    public float fuerzaLanzarCabeza;

    public GameObject punto1;
    public GameObject punto2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;


    [SerializeField] private int puntoQueRota;

    public float horizontal;
    public float vertical;
    public Vector2 velocidad;

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
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (tengoBrazo)
            {
                ApuntarBrazo();
            }
            if (Input.GetAxis("Jump") > 0.1f)
            {
                LanzarCabeza();
            }
        }
        if (tengoPierna)
            velocidad = piernasRB.velocity;
    }


    void FixedUpdate()
    {
        if (tengoCabeza)
        {
            if (!tengoPierna)
            {
                Rotar();
            }
            else
            {
                Andar();
            }
        }
    }

    private void Rotar()
    {
        if (puntoQueRota == 1)
        {
            if (horizontal > 0.1f)
            {
                rb1.angularVelocity -= aceleracionAngular * Time.deltaTime;
            }

            if (horizontal < -0.1f)
            {
                rb1.angularVelocity += aceleracionAngular * Time.deltaTime;
            }
            rb1.angularVelocity = Mathf.Clamp(rb1.angularVelocity, -maxVelocidadAngular, maxVelocidadAngular);
        }

        else if (puntoQueRota == 2)
        {
            if (horizontal > 0.1f)
            {
                rb2.angularVelocity -= aceleracionAngular * Time.deltaTime;
            }

            if (horizontal < -0.1f)
            {
                rb2.angularVelocity += aceleracionAngular * Time.deltaTime;
            }
            rb2.angularVelocity = Mathf.Clamp(rb2.angularVelocity, -maxVelocidadAngular, maxVelocidadAngular);
        }

    }

    private void Andar()
    {
        piernasRB.velocity = new Vector2(velocidadAndar * horizontal, piernasRB.velocity.y);/*
        if (horizontal > 0.1f)
        {
            //piernasRB.AddForce(Vector2.right * velocidadAndar,ForceMode2D.Impulse);
            //piernasRB.velocity += Vector2.right * velocidadAndar;
            //piernasRB.velocity += Vector2.right * velocidadAndar;
        }
        else if (horizontal < -0.1f)
        {
            //piernasRB.AddForce(Vector2.left * velocidadAndar,ForceMode2D.Impulse);
            //piernasRB.velocity += Vector2.left * velocidadAndar;
            piernasRB.velocity = new Vector2(-velocidadAndar, piernasRB.velocity.y);
        }
        */
        if (vertical > 0.1f && groundCheck.grounds > 0)
        {
            piernasRB.velocity += Vector2.up * fuerzaSalto;
            //piernasRB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            //piernasRB.AddForce(piernas.transform.position + Vector3.up * fuerzaSalto);
        }
        piernasAnim.SetFloat("Velocidad", Mathf.Abs(horizontal));

    }

    private void ApuntarBrazo()
    {
        var mouse = Input.mousePosition;
        var mouseScreenPosition = Camera.main.ScreenToWorldPoint(mouse);

        var angleRad = Mathf.Atan2(mouseScreenPosition.y - transform.position.y, mouseScreenPosition.x - transform.position.x);

        var angleDeg = (180 / Mathf.PI) * angleRad;

        brazo.transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);
    }

    private void LanzarCabeza()
    {
        tengoCabeza = false;
        cabeza.transform.SetParent(null);
        cabeza.GetComponent<CalaveraController>().enabled = true;
        cabeza.GetComponent<Rigidbody2D>().simulated = true;
        if (!tengoBrazo)
        {
            cabeza.GetComponent<Rigidbody2D>().AddForce((cabeza.transform.position - transform.position) * fuerzaLanzarCabeza);
        }
        else
        {
            cabeza.GetComponent<Rigidbody2D>().AddForce((brazo.transform.GetChild(0).GetChild(0).position - transform.position).normalized * fuerzaLanzarCabeza * 3f);
        }
        cabeza.layer = 12;
        ultimoCogido = Time.timeSinceLevelLoad;
    }


    public void TocaElSuelo(GameObject punto)
    {
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
        if (collision.CompareTag("Cabeza") && ultimoCogido + cooldownCogido < Time.timeSinceLevelLoad)
        {
            tengoCabeza = false;
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
        else if (tengoCabeza && !tengoPierna && collision.CompareTag("Piernas") && ultimoCogido + cooldownCogido < Time.timeSinceLevelLoad)
        {
            tengoCabeza = false;
            Invoke(nameof(ControllerCD), 0.3f);

            piernas = collision.gameObject.transform.gameObject;
            transform.DOMove(piernas.transform.GetChild(2).position, 0.3f).Play();
            transform.SetParent(null);
            punto1.transform.SetParent(transform.GetChild(0));
            punto2.transform.SetParent(transform.GetChild(0));
            transform.SetParent(piernas.transform);



            piernasAnim = piernas.GetComponent<Animator>();
            piernasRB = piernas.GetComponent<Rigidbody2D>();
            rb1.angularVelocity = 0f;
            rb1.simulated = false;
            rb2.angularVelocity = 0f;
            rb2.simulated = false;

            groundCheck = piernas.transform.GetChild(3).GetComponent<GroundCheck>();
            tengoPierna = true;

            transform.DOLocalRotate(Vector3.zero, 0.3f).Play();
        }
        else if (tengoCabeza && !tengoBrazo && collision.CompareTag("Brazo") && ultimoCogido + cooldownCogido < Time.timeSinceLevelLoad)
        {
            brazo = collision.gameObject.transform.root.gameObject;
            brazo.transform.root.DOMove(punto1.transform.position, 0.1f).Play();
            brazo.transform.root.SetParent(punto1.transform);
            tengoBrazo = true;
        }
    }

    private void ControllerCD()
    {
        tengoCabeza = !tengoCabeza;
    }

}
