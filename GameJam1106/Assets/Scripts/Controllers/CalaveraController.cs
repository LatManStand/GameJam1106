using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalaveraController : MonoBehaviour
{
    public float maxVelocidadAngular;
    public float momentoAngular;
    public float aceleracionAngular = 2f;

    private Rigidbody2D rb2d;

    public Extremidad llevada;
    public float fuerza;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            rb2d.angularVelocity -= aceleracionAngular * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            rb2d.angularVelocity += aceleracionAngular * Time.deltaTime;
        }
        rb2d.angularVelocity = Mathf.Clamp(rb2d.angularVelocity, -maxVelocidadAngular, maxVelocidadAngular);
        momentoAngular = rb2d.angularVelocity;
    }
}
