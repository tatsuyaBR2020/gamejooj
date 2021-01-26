using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public float TempoDaCut;
    public string trigger;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
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
}
