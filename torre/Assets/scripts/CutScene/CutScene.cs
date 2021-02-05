using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public float TempoDaCut;
    public string trigger;
    public GameObject luz;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(trigger);
        StartCoroutine(Cut());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            anim.SetTrigger(trigger);
            StartCoroutine(Cut());
        }
    }

    IEnumerator Cut()
    {
        yield return new WaitForSeconds(TempoDaCut);
        anim.enabled = false;
    }

    public void AtivarLuz()
    {
        luz.SetActive(true);
    }
}
