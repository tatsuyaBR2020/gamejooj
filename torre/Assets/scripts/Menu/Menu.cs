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
	public Animator effect;
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
		effect.gameObject.SetActive(true);
        effect.Play("Fade_In");
		StartCoroutine(comecarJogo());
    }
	
	IEnumerator comecarJogo()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(nomeDaCena);
	}

    public void Opcoes(string state)
    {
        cutScene.Play(state);
    }
	
	public void Aumentar(RectTransform trans)
	{
		trans.localScale = new Vector3(1.2f,1.2f,1);
	}
	
	public void Diminuir(RectTransform trans)
	{
		trans.localScale = new Vector3(1,1,1);
	}

    public void Sair()
    {
        Application.Quit();
    }
}
