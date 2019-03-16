using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vida : MonoBehaviour
{
    public Sprite[] corazones;
    void Start()
    {
        CambioVida(5);
    }

    void Update()
    {
        
    }


    public void CambioVida(int pos){
        this.GetComponent<Image>().sprite = corazones[pos];
    }
}
