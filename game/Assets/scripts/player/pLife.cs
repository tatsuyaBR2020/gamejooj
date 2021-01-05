using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pLife : MonoBehaviour
{
    public GameObject vida;
    public int vidas = 1;
    public float Distancia;
    public List<GameObject> x = new List<GameObject>();

    private void Start()
    {
        AddVida();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            AddVida();
        }
    }

    public void AddVida()
    {
        x.Add(vida);
        int i = x.Count - 1;
        x[i].transform.position = new Vector3(x[i].transform.position.x + Distancia,x[0].transform.position.y,0);
        Instantiate(x[i],x[i].transform.position,transform.rotation);
        Debug.Log("esta Funcionando");
    }
}
