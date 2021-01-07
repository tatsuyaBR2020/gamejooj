using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarQuarto : MonoBehaviour
{
    public string nomeCena;
    public float Tempo;
    public Animator animEffect;
    public bool Aberto = false;

    bool totalmenteAberto = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown("e") && !Aberto)
            {
                GetComponent<Animator>().SetTrigger("open");
                StartCoroutine(abrindo(Tempo));
            }
            if (Aberto)
            {
                teleport.nomeCena = nomeCena;
                animEffect.SetTrigger("FadeIn");
            }
        }
    }

    IEnumerator abrindo(float temp)
    {
        yield return new WaitForSeconds(temp);
        Aberto = true;
    }
}
