using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarQuarto : MonoBehaviour
{
    public string nomeCena;
    public Animator animEffect;
    public bool Aberto = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleport.nomeCena = nomeCena;
        }
    }
}
