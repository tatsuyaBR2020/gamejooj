using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passarQuarto : MonoBehaviour
{
    public bool aberto = false;
    public string nomeCena;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(aberto)
                SceneManager.LoadScene(nomeCena);
        }
    }
}
