using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public string nomeCena;
    public Animator animEffect;
    public void comecar()
    {
        animEffect.gameObject.SetActive(true);
        teleport.nomeCena = nomeCena;
        animEffect.SetTrigger("FadeIn");
        PlayerPrefs.SetInt("Vida", 1);

    }
    public void quit()
    {
        Application.Quit();
    }
}