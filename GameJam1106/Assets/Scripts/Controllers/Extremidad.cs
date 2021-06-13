using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extremidad : MonoBehaviour
{
    public Transform encajaCuerpo;
    public Transform encajaCabeza;
    public CuerpoController cuerpo;
    public CalaveraController cabeza;
    public bool esPiedra;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cuerpo") && !esPiedra)
        {
            cuerpo = collision.GetComponent<CuerpoController>();
            if (cuerpo.ultimoCogido + cuerpo.cooldownCogido < Time.timeSinceLevelLoad)
            {
                transform.SetParent(encajaCuerpo);
                transform.DOMove(encajaCuerpo.position, 0.3f);
                transform.DOLocalRotate(Vector3.zero, 0.3f);
                TriggerEnter();
            }
            else
            {
                cuerpo = null;
            }
        }
        else if (collision.CompareTag("Cabeza"))
        {
            cabeza = collision.GetComponent<CalaveraController>();
            if (cabeza.ultimaCogida + cabeza.cogerCooldown < Time.timeSinceLevelLoad)
            {
                transform.SetParent(encajaCabeza);
                transform.DOMove(encajaCabeza.position, 0.3f);
                transform.DOLocalRotate(Vector3.zero, 0.3f);
                cabeza.llevada = this;
                TriggerEnter();
            }
            else
            {
                cabeza = null;
            }
        }
    }


    public virtual void TriggerEnter()
    {
    }
}
