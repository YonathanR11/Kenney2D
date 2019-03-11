using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSuelo : MonoBehaviour
{

    private PlayerControl player;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerControl>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Platform"){
            rb2d.velocity = new Vector3(0f,0f,0f);
            player.transform.parent = col.transform;
            player.tocasuelo = true;
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Piso"){
            player.tocasuelo = true;
        }
        if(col.gameObject.tag == "Platform"){
            player.transform.parent = col.transform;
            player.tocasuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Piso"){
        player.tocasuelo = false;
    }
        if(col.gameObject.tag == "Platform"){
        player.transform.parent = null;
        player.tocasuelo = false;
    }
    }
}
