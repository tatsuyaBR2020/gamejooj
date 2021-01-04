@@ -0,0 +1,114 @@
﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public class Conversa
{
    public string dialog;
    public bool _npcTalk;
}
public class Dialog : MonoBehaviour
{
    [Header("Config")]
    public Conversa[] stock;
    public string nomeNpc;
    public bool podeAbrir;
    [Header("Imports")]
    public TextMeshProUGUI _textoDialogo;//texto para mostrar o dialogo
    public TextMeshProUGUI _textName;//texto para por o nome da pessoa que ta falano
    public GameObject _DiaObj;//obj do dialogo

    private int index = 0;
    private int selected = 0;
    private char[] caracteres;
    private float Tempo, Distancia;
    private bool open = false;
    private GameObject pl;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distancia = Vector2.Distance(transform.position, pl.transform.position);
        if (Distancia < 3)
        {
            podeAbrir = true;
        }
        else
        {
            podeAbrir = false;
        }
        if (podeAbrir)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!open)
                {
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

            if (index < caracteres.Length)
            {
                Ditar();
            }
        }
    }

    void MostrarDialog()
    {
        index = 0;
        open = true;
        selected = 0;
        _textoDialogo.text = "";
        _DiaObj.SetActive(true);
        caracteres = stock[0].dialog.ToCharArray();
        if (stock[selected]._npcTalk)
            _textName.text = "Nome:" + nomeNpc;
        else
            _textName.text = "Nada";
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
        if (Input.GetKeyDown("e") && selected > stock.Length - 1)
        {
            Fechar();
            return;
        }

        selected += 1;
        index = 0;
        _textoDialogo.text = "";
        caracteres = stock[selected].dialog.ToCharArray();

    }
    void Fechar()
    {
        open = false;
        _DiaObj.SetActive(false);
    }
}