using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] float speed;
	
	[Header("Imports")]
	[SerializeField] Rigidbody2D rb;
	
	PlayerInput inputs = new PlayerInput();
	
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs.Move() * speed * Time.deltaTime);
    }
}
