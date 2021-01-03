using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interacao : MonoBehaviour
{
    [Header("Config")]
    public string[] stock;
    public string nomeNpc;
    public bool podeAbrir;
    public float distMax;
    [Header("Imports")]
    public TextMeshProUGUI _textoDialogo;//texto para mostrar o dialogo
    public TextMeshProUGUI _textName;//texto para por o nome da pessoa que ta falano
    public GameObject _DiaObj;//obj do dialogo
    public GameObject _intObj;

    private int index = 0;
    private int selected = 0;
    private char[] caracteres;
    private float Tempo,Distancia;
    private bool open = false,inter;
    private GameObject pl;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distancia = Vector2.Distance(transform.position, pl.transform.position);
        if(Distancia > distMax)
        {
            podeAbrir = false;
        }

        if (Distancia < distMax)
        {
            podeAbrir = true;
            inter = true;
            _intObj.SetActive(true);
        }else if (inter)
        {
            inter = false;
            _intObj.SetActive(false);
        }
            
        if (podeAbrir)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!open)
                {
                    inter = true;
                    MostrarDialog();
                }
                else
                {
                    ProximoDialogo();
                }
            }
        }
        
        if (open)
        {
            
            if(index < caracteres.Length)
            {
                Ditar();
            }
        }
    }

    void MostrarDialog()
    {
        FindObjectOfType<pMove>().enabled = false;
        FindObjectOfType<pMove>().inputs.x = 0;
        index = 0;
        open = true;
        selected = 0;
        _textoDialogo.text = "";
        _DiaObj.SetActive(true);
        caracteres = stock[0].ToCharArray();
    }

    void Ditar()
    {
        Tempo += Time.deltaTime;
        if (Tempo >= 0.2f)
        {
            _textoDialogo.text += caracteres[index];
            index++;
        }
    }

    void ProximoDialogo()
    {
        if (Input.GetKeyDown("e") && selected >= stock.Length - 1)
        {
            Fechar();
            return;
        }

        selected += 1;
        index = 0;
        _textoDialogo.text = "";
        caracteres = stock[selected].ToCharArray();

    }
    void Fechar()
    {
        open = false;
        _DiaObj.SetActive(false);
        FindObjectOfType<pMove>().enabled = true;
    }
}
