using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float distMax = 1;
    [SerializeField] Vector2 tLetras;
    [SerializeField] bool temItem;
    [SerializeField] List<string> _dialogo = new List<string>();
    [Header("Imports")]
    [SerializeField] GameObject _objDialogo;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _textNome;

    //privates
    char[] caracteres;
    int selected, CurrentLetra;
    bool open;
    float tempo;
    Player pl;

    void Start()
    {
        open = false;
        _objDialogo.SetActive(open);
        pl = FindObjectOfType<Player>();
    }

    void Update()
    {
            if (Input.GetKeyDown("e") && open)
            {
                if (CurrentLetra < caracteres.Length)
                {
                    CurrentLetra = caracteres.Length;
                    _text.text = _dialogo[selected];
                }
                else
                {
                    PassarPaginas();
                }
        }

        if (open)
        {
            if(CurrentLetra < caracteres.Length)
            {
                float temp;

                if (caracteres[CurrentLetra] == ',')
                    temp = tLetras.y;
                else
                    temp = tLetras.x;

                if (tempo < temp)
                {
                    tempo += Time.deltaTime;
                }
                else
                {
                    Ditar();
                }
            }
        }
    }

    public void Abrir()
    {
        open = true;
        _objDialogo.SetActive(open);
        selected = 0;
        CurrentLetra = 0;
        _text.text = "";
        caracteres = _dialogo[0].ToCharArray();
        pl.enabled = false;
    }
    void fechar()
    {
        open = false;
        pl.enabled = true;
        pl.Abriu = false;
        _objDialogo.SetActive(false);
        if(temItem){
            //pl.GetComponent<inventory>();
        }
    }

    void PassarPaginas()
    {
        selected += 1;
        if (selected < _dialogo.Count)
        {
            caracteres = _dialogo[selected].ToCharArray();
            CurrentLetra = 0;
            _text.text = "";
        }
        else
        {
            fechar();
        }
    }
    void Ditar()
    {
        _text.text += caracteres[CurrentLetra];
        CurrentLetra++;
        tempo = 0;
    }
}
