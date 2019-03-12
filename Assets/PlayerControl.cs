using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool tocasuelo;
    public float poderSalto = 6.5f;

    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private bool salto;
    private bool dobleSalto;
    private bool movement = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("TocaSuelo", tocasuelo);

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(tocasuelo){
            salto = true;
            dobleSalto = true;
            }else if(dobleSalto){
                salto = true;
            dobleSalto = false;
            }
        }

    }

    void FixedUpdate()
    {

        Vector3 fixVelocidad= rb2d.velocity;
        fixVelocidad.x *= 0.75f;

        if(tocasuelo){
            rb2d.velocity = fixVelocidad;
        }


        float h = Input.GetAxis("Horizontal");
        if(!movement) h=0;

        rb2d.AddForce(Vector2.right * speed * h);

        float  limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if(h > 0.1f){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(h < -0.1f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if(salto){
            rb2d.velocity = new Vector2(rb2d.velocity.x,0);
            rb2d.AddForce(Vector2.up * poderSalto, ForceMode2D.Impulse);
            salto = false;
        }

    }

    void OnBecameInvisible(){
        transform.position = new Vector3(-12,0,0);
    }

    public void EnemyJump(){
        salto = true;
    }

    public void EnemyKnockback(float enemyPosX){
        salto = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * poderSalto, ForceMode2D.Impulse);
        movement = false;
        Invoke("EnableMovement",0.7f);
        spr.color = Color.red;
    }

    void EnableMovement(){
        movement = true;
        spr.color = Color.white;
    }

}
