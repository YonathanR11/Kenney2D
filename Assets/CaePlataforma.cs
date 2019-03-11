using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaePlataforma : MonoBehaviour
{

    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb2d;
    private PolygonCollider2D pc2d;
    private Vector3 inicio;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pc2d = GetComponent<PolygonCollider2D>();
        inicio = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            Invoke("CaePlataformaM", fallDelay);
            Invoke("aparecePlataformaM", fallDelay + respawnDelay);
        }
    }

    void CaePlataformaM(){
        rb2d.isKinematic = false;
        pc2d.isTrigger = true;
    }

    void aparecePlataformaM(){
        transform.position = inicio;
        rb2d.isKinematic = true;
        rb2d.velocity = Vector3.zero;
        pc2d.isTrigger = false;
    }

}
