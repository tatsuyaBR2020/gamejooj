using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bispo : MonoBehaviour
{
    public float speed, tempoParado;
    public Transform top, Down;

    public bool andar, isUp;
    bool passou;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < top.position.y && transform.position.y > Down.position.y)
        {
            andar = true;
            passou = false;
        }
        else if (!passou)
        {
            passou = true;
            isUp = !isUp;
            StartCoroutine(Timer());
        }
    }

    private void FixedUpdate()
    {
        if (andar)
        {
            if (isUp)
            {
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                transform.position += (transform.up * -1) * speed * Time.deltaTime;
            }
        }
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
