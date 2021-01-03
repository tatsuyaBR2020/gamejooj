using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{
    public float speed;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            atirador.podeAtacar = true;
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("botao"))
        {
            var bot = other.gameObject.GetComponent<botao>();
            bot.apertado = true;
            Destroy(gameObject);
        }
    }
}
