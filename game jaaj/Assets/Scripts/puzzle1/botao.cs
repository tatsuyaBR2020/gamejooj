using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    public Animator animPorta;
    public bool apertado = false;

    void Update()
    {
        if (apertado)
        {
            animPorta.SetTrigger("abriu");
        }
    }
}
