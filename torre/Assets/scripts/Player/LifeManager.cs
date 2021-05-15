using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int life = 5;
    public float distanciaDasVidas = .2f;
    public GameObject pre;
    public Transform lifespoint;
    public List<GameObject> objsLife = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        objsLife = new List<GameObject>();
        //life = PlayerPrefs.GetInt("Life");
        for(int i = 0; i < life; i++)
        {
            GameObject objVida = Instantiate(pre, transform.position, transform.rotation);
            if(i == 0)
            {
                objsLife.Add(objVida);
                objsLife[i].transform.position = lifespoint.position;
            }
            else
            {
                objsLife.Add(objVida);
                objsLife[i].transform.position = objsLife[i - 1].transform.position + new Vector3(distanciaDasVidas, 0, 0);
            }
            objVida.transform.SetParent(lifespoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("t"))
        {
            GameObject objVida = Instantiate(pre, transform.position, transform.rotation);
            life++;
            objsLife.Add(objVida);
            objsLife[objsLife.Count - 1].transform.position = objsLife[objsLife.Count - 2].transform.position + new Vector3(distanciaDasVidas, 0, 0);
        }
    }

    void Add()
    {

    }
}
