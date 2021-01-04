using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atirador : MonoBehaviour
{
    public float minDistance;
    public Transform target;
    public GameObject projetil;
    public static bool podeAtacar;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        podeAtacar = true;
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance && podeAtacar)
        {
            podeAtacar = false;
            Instantiate(projetil, transform.position, transform.rotation);
            anim.SetTrigger("atacou");
        }
    }
}