using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoRotacionCuerpo : MonoBehaviour
{
    private CuerpoController cuerpo;

    private void Awake()
    {
        cuerpo = transform.parent.parent.GetComponent<CuerpoController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            cuerpo.TocaElSuelo(gameObject);
        }
    }
}
