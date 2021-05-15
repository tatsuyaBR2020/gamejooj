using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    public string horizontal = "Horizontal";
	public string vertical = "Vertical";
	
	public string interact = "Interact";
	
	
	public Vector2 Move()
	{
		float x = Input.GetAxisRaw(horizontal);
		float y = Input.GetAxisRaw(vertical);
		
		if(x != 0  || y != 0)
		{
			PlayerInteract.direction = new Vector2(Mathf.Sign(x), Mathf.Sign(y));
		}
		
		return new Vector2(x, y);
	}
}
