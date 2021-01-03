using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class opcoes : MonoBehaviour
{
    public float maxVol, minVol;
    public Slider vol;
    public AudioMixer mixer;

    float currentVol;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("volume", maxVol);
        currentVol = PlayerPrefs.GetFloat("volume");
        vol.value = currentVol;
        vol.maxValue = maxVol;
        vol.minValue = minVol;
    }

    // Update is called once per frame
    void Update()
    {
        currentVol = vol.value;
        mixer.SetFloat("vol", currentVol);
    }
}
