using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public float Speed,tempoParado;
    public Transform left, right;

    public bool andar,isRight;
    bool passou;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(transform.position.x < right.position.x && transform.position.x > left.position.x)
        {
            andar = true;
            passou = false;
        }
        else if(!passou)
        {
            passou = true;
            isRight = !isRight;
            StartCoroutine(Timer());
            if (isRight)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }

    private void FixedUpdate()
    {
        if(andar)
            transform.position += transform.right * Speed * Time.deltaTime;
    }

    IEnumerator Timer()
    {
        andar = false;
        yield return new WaitForSeconds(tempoParado);
        andar = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
