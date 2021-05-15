using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface Interact{
	public void Executar();
}

public class interacao : MonoBehaviour, Interact
{
    [SerializeField] List<string> _dialogo = new List<string>();
	[SerializeField] DialogControl dialog;
	
	public void Executar()
	{
		Abrir();
	}

    void Abrir()
    {
		if(!DialogControl.open)
			dialog.Abrir(_dialogo);
    }
}
