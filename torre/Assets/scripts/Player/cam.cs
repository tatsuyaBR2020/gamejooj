using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [SerializeField] float prioridade;
	
	[SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
		if(target != null)
			transform.position = Vector3.Lerp(transform.position, target.position, prioridade / 2) + new Vector3(0,0,-10);
		
	}
}
