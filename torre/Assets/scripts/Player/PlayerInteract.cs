using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	[SerializeField] float distance;
	[SerializeField] LayerMask layerInteract;
	
	[SerializeField] GameObject botao;
	
	public static Vector2 direction = new Vector2(0, 1);
	
	PlayerInput inputs = new PlayerInput();
	
    void Update()
    {
        RayCheck();
    }

	RaycastHit2D ray()
	{
		return Physics2D.Raycast(transform.position, direction, distance, layerInteract);
	}
	
	void RayCheck()
	{
		RaycastHit2D hit = ray();
		if(hit.collider != null)
		{
			botao.SetActive(true);
			if(Input.GetKeyDown("e"))
			{
				hit.collider.gameObject.GetComponent<Interact>().Executar();
			}
		}else{
			botao.SetActive(false);
		}
	}
}
