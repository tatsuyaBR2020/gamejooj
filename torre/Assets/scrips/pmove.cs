using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmove : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    Vector2 inputs;
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
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * speed * Time.deltaTime);
    }
}
