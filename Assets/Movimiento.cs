using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Vector3 inicio, fin;

    // Start is called before the first frame update
    void Start()
    {
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
            target.position = (target.position == inicio) ? fin : inicio;
        }

    }


}
