using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMovement : MonoBehaviour
{
    public float _speed;

    //privates
    private float _realSpeed;
    private Rigidbody2D rb;
    public Vector2 inputs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");

        if (inputs.x != 0 && inputs.y != 0)
            _realSpeed = _speed / 1.5f;
        else
            _realSpeed = _speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * _realSpeed * Time.deltaTime);
    }
}
