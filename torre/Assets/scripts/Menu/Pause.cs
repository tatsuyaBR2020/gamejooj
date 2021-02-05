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

    public GameObject _Pause;
    public Slider volControl;
	public TextMeshProUGUI txtVol;
    public AudioMixer mixer;
    public Save save;

    Player pl;
    bool pausado;
    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<Player>();
        _Pause.SetActive(false);
        volControl.maxValue = volMax;
        volControl.minValue = volMin;
        volControl.value = save.CurrentVol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausado = !pausado;
            if (pausado)
            {
                _Pause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _Pause.SetActive(false);
                Time.timeScale = 1;
            }
        }

        mixer.SetFloat("Vol", volControl.value);
        save.CurrentVol = volControl.value;
		txtVol.text = "volume: " + volControl.value;
    }
}
