using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebasaltoputosalto : MonoBehaviour
{
    public float fuerza;
    public float vertical;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (vertical > 0.1f)
        {
            rb.velocity = Vector2.up * fuerza;
        }
    }
}
