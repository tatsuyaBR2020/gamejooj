using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pLife : MonoBehaviour
{
    public Transform lifeinicial;
    public GameObject vida;
    public int vidas = 1;
    public float Distancia;
    public List<float> x = new List<float>();

    private void Start()
    {
        reloadLifes();
    }

    public void reloadLifes()
    {
        x = new List<float>(vidas);
        for(int i = 0;i < vidas; i++)
        {
            if(i == 0)
            {
                var obj = Instantiate(vida, lifeinicial.position, lifeinicial.rotation);
                x[0] = obj.transform.position.x;
                Debug.Log(x[0]);
            }
            if(i > 0)
            {
                var obj = Instantiate(vida,new Vector3(x[i - 1] +Distancia, 0, 0), transform.rotation);
                x[i] = obj.transform.position.x;
            }
        }
    }
}
