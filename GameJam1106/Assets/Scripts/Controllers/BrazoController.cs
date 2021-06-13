using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoController : Extremidad
{
    public override void TriggerEnter()
    {
        if (cuerpo != null)
        {
            cuerpo.tengoBrazo = true;
        }
        else if (cabeza != null)
        {

        }
    }


}
