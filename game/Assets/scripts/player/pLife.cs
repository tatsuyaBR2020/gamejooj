using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pLife : MonoBehaviour
{
    public Transform point;
    public GameObject vida;
    public int vidas = 1;
    public float Distancia;
    public List<GameObject> x = new List<GameObject>();

    private void Start()
    {
        for(int i = 0;i < vidas; i++)
        {
            AddVida();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            AddVida();
        }
        if (Input.GetKeyDown("t"))
        {
            Remove();
        }
    }
    public void AddVida()
    {
        x.Add(vida);
        int i = x.Count - 2;
        if(x.Count > 1)
        {
            x[x.Count - 1].transform.position = new Vector3(x[i].transform.position.x + Distancia, x[0].transform.position.y, 0);
            x[x.Count - 1] = Instantiate(vida, x[x.Count - 1].transform.position, transform.rotation);
            x[x.Count - 1].transform.SetParent(point);
        }
        if(x.Count == 1)
        {
            x[0] = Instantiate(vida, point.position, transform.rotation);
            x[0].transform.position = new Vector3(point.position.x, point.transform.position.y, 0);
            x[0].transform.SetParent(point);
        }
        Debug.Log("esta Funcionando");
    }

    public void Remove()
    {
        int i = x.Count - 1;
        Destroy(x[i]);
        x.Remove(x[i]);
    }
}
