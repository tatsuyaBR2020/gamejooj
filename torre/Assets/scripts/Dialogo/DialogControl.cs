using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogControl : MonoBehaviour
{
	[Header("Config")]
    [SerializeField] Vector2 tLetras;
	
	[Header("Imports")]
    [SerializeField] GameObject _objDialogo;
	[SerializeField] GameObject _btnPass;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _textNome;
	
    public static bool open;
	public static DialogControl instance;
	
	List<string> sentences = new List<string>();
	
	int selected = 0;
	
	char[] caracteres;
    bool canPass = false;
    float tempo;
	
	void Start()
	{
		instance = this;
	}
	
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
        {
            if(!canPass)
			{
				_text.text = sentences[selected];
				_btnPass.SetActive(true);
				canPass = true;
			}
			
                PassarPaginas();
        }
    }
	
	public void Abrir(List<string> sentences)
	{
		this.sentences = sentences;
		selected = 0;
		canPass = false;
		caracteres = sentences[0].ToCharArray();
		_btnPass.SetActive(false);
		open = true;
		_objDialogo.SetActive(true);
		_text.text = "";
		Ditar();
	}
	
	void fechar()
    {
        open = false;
		selected = 0;
        _objDialogo.SetActive(open);
    }

    public void PassarPaginas()
    {
        selected = 1;
        if (selected >= sentences.Count)
        {
            fechar();
        }
        else
        {
			caracteres = sentences[selected].ToCharArray();
            _text.text = "";
			Ditar();
        }
    }
    void Ditar()
    {
        StartCoroutine(letter());
    }
	
	IEnumerator letter()
	{
		canPass = false;
		int sele = selected;
		foreach(char _letter in caracteres)
		{
			if(sele != selected || canPass)
				break;
			
			_text.text += _letter;
			if(_letter != ',')
			{
				yield return new WaitForSeconds(tLetras.x);
			}else
				yield return new WaitForSeconds(tLetras.y);
		}
		canPass = true;
		_btnPass.SetActive(true);
	}
}
