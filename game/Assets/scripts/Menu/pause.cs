using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject _pause;

    bool open = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open = !open;
            if (open)
            {
                _pause.SetActive(open);
                Time.timeScale = 0;
            }
            else
            {
                _pause.SetActive(open);
                Time.timeScale = 1;
            }
        }
    }
}
