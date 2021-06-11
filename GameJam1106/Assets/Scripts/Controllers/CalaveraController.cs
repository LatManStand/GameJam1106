using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalaveraController : MonoBehaviour
{
    public float maxVelocidad;
    public float momentoAngular;
    public float aceleracion = 2f;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
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
