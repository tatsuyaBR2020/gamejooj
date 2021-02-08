using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("configs")]
    public float speed;
    public float distanciaDainteracao;
    public bool Abriu = false;
    [Header("imports")]
    [SerializeField] GameObject Botao;
    public GameObject album;

    Rigidbody2D rb;
    Vector2 inputs;
    Vector2 direction;
    bool estaAtivado;
    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        Botao.SetActive(false);
        direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {

        //ABRIR INVENTARIO
        if (Input.GetKeyDown("i")){
            estaAtivado = !estaAtivado;
            album.SetActive(estaAtivado);
        }

        if (estaAtivado == true){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }


        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");

        if (inputs != Vector2.zero)
            direction = inputs;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distanciaDainteracao);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 3)
            {
                Botao.SetActive(true);
                if (Input.GetKeyDown("e") && !Abriu)
                {
                    hit.collider.GetComponent<Interacao>().Abrir();
                    Abriu = true;
                }
            }
        }
        else
        {
            Botao.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * speed * Time.deltaTime);
    }
}
