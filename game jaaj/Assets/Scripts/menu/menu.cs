using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public string nomeCena;
    public Image btnComecar;
    public Sprite sprComecar;

    public float temp;

    public void comecar()
    {
        //btnComecar.sprite = sprComecar;
        SceneManager.LoadScene(nomeCena);
    }
    public void quit()
    {
        Application.Quit();
    }
}
