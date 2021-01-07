﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Torre : MonoBehaviour
{
    public float _Speed;
    public float TempoParado;
    [SerializeField] bool _isRight;
    public Transform left, Right;

    public bool passou = false;
    public bool pode = true;
    public float Temporizador = 0;
    // Update is called once per frame
    void Update()
    {
        if (pode)
        {
            if (_isRight)
            {
                transform.Translate(new Vector3(_Speed, 0, 0) * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(_Speed * -1, 0, 0) * Time.deltaTime);
            }
        }
        if (passou)
        {
            pode = false;
            Temporizador += Time.deltaTime;
            if(Temporizador > TempoParado)
            {
                passou = false;
                pode = true;
                _isRight = !_isRight;
                Temporizador = 0;
                StartCoroutine(contaTempo());
            }
        }

        if(!j)
        if (transform.position.x > Right.position.x || transform.position.x < left.position.x)
        {
            passou = true;
        }
        else
        {
            passou = false;
            Temporizador = 0;
        }
    }
    bool j = false;
    IEnumerator contaTempo()
    {
        j = true;
        yield return new WaitForSeconds(0.4f);
        j = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Speed = 0;
            FindObjectOfType<teleport>().gameObject.SetActive(true);
            var v = collision.gameObject.GetComponent<pLife>().vidas;
            teleport.nomeCena = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetInt("Vida", v - 1);
            FindObjectOfType<teleport>().gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
        }
    }
}
