using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouseControl : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Vector3 inicio, fin;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(target != null){
            target.parent = null;
            inicio = transform.position;
            fin = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(target != null){
            float fixSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixSpeed);
        }

        if(transform.position == target.position){
            // target.position = (target.position == inicio) ? fin : inicio;
            if(target.position == inicio){
                target.position = fin;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }else{
                target.position = inicio;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

        // if(rb2d.velocity.x > 0.01f && rb2d.velocity.x < -0.01f){
        //     speed = -speed;
        //     rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        // }

        // if(speed < 0){
        //     transform.localScale = new Vector3(1f, 1f, 1f);
        // }else if(speed > 0){
        //     transform.localScale = new Vector3(-1f, 1f, 1f);
        // }

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            // float yOffset = 0.2f;
            if(transform.position.y < col.transform.position.y){
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }else{
                col.SendMessage("EnemyKnockback", transform.position.x);
            }
        }
    }
}
