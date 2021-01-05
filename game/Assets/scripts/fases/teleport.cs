using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public static string nomeCena;

    private void Start()
    {
        GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void passar()
    {
        SceneManager.LoadScene(nomeCena);
    }
    public void Desativar()
    {
        gameObject.SetActive(false);
    }
}
