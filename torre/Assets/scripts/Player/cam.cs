using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float prioridade;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, FindObjectOfType<Player>().transform.position, prioridade / 2) + new Vector3(0,0,-10);
    }
}
