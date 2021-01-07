using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmanager : MonoBehaviour
{
    public GameObject enygma;
    public Animator animPorta;
    public Animator animArmadilha;
    public float distanciaMin;
    public static int ItemPuzzle; 

    void Start()
    {
        //ItemPuzzle = PlayerPrefs.GetInt("Puzzle3");
        ItemPuzzle = 1;
    }

    void Update()
    {
        var Distancia = Vector3.Distance(transform.position, FindObjectOfType<pMove>().transform.position);

        if(Distancia < distanciaMin)
        {
            if(Input.GetKeyDown("e") && ItemPuzzle == 1)
            {
                animPorta.SetTrigger("open");
            }
            else if (Input.GetKeyDown("e"))
            {
                animArmadilha.SetTrigger("Ativar");
            }
        }
    }


    void IniciarEnygma()
    {
        for()
    }
}
