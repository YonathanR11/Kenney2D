using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LlaveControl : MonoBehaviour
{

    public Sprite[] llaveIU;

    void Start()
    {
        // CambioLlave(0);
    }

    public void Cogida(){
        Destroy(gameObject);
    }

    public void CambioLlave(int pos){
        this.GetComponent<Image>().sprite = llaveIU[pos];
    }

}
