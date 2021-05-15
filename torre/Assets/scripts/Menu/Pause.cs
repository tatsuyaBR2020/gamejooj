using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public float volMax;
    public float volMin;

    [SerializeField] GameObject _Pause;
    [SerializeField] Slider volControl;
	[SerializeField] TextMeshProUGUI txtVol;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Save save;
    public bool pausado { get; set;}
    public bool podeAbrir { get; set;}
    // Start is called before the first frame update
    void Start()
    {
        setarVolumeinicial();
    }

    // Update is called once per frame
    void Update()
    {
        abrirInventario();
        setarVolume();
    }

    void abrirInventario()
    {
        if (podeAbrir)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //var player = FindObjectOfType<PMove>();
                pausado = !pausado;
                if (pausado)
                {
                    _Pause.SetActive(true);
                    Time.timeScale = 0;
                    //player.podeMovimentar = false;
                }
                else
                {
                    _Pause.SetActive(false);
                    Time.timeScale = 1;
                    //player.podeMovimentar = true;
                }
            }
    }

    void setarVolume()
    {
        if (pausado)
        {
            mixer.SetFloat("Vol", volControl.value);
            save.CurrentVol = volControl.value;
            txtVol.text = "volume: " + volControl.value;
        }
    }

    void setarVolumeinicial()
    {
        podeAbrir = true;
        _Pause.SetActive(false);
        volControl.maxValue = volMax;
        volControl.minValue = volMin;
        volControl.value = save.CurrentVol;
    }
}
