using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	public Animator anim;
	public PlayerMovement player;
	
	public static Fade instance;
	public static string cena;
	
    void Start()
    {
        instance = this;
    }
	
	public void newState(string state)
	{
		anim.Play(state);
	}
	
	public void PassarCenario()
	{
		SceneManager.LoadScene(cena);
	}
	
	public void SetarPlayer(bool i)
	{
		player.enabled = i;
	}
}
