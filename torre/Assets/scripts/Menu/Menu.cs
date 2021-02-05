using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public string nomeDaCena;
    public float minVol, maxVol;
    public Slider volControl;
    public AudioMixer mixer;
    public Animator cutScene;
    public Save save;

    bool openOpcoes = false;

    void Awake()
    {
        volControl.minValue = minVol;
        volControl.maxValue = maxVol;
        volControl.value = save.CurrentVol;
    }

    void Update()
    {
        save.CurrentVol = volControl.value;
        mixer.SetFloat("Vol", save.CurrentVol);
    }

    public void Comecar()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Opcoes()
    {
        openOpcoes = !openOpcoes;
        cutScene.SetBool("opcoes", openOpcoes);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
