using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl instance;

    public AudioClip hit;
    public AudioClip salto;
    public AudioClip llave;

    public AudioSource audioSource;

    void Awake()
    {
        if(SoundControl.instance == null){
            SoundControl.instance = this;
        }else if(SoundControl.instance != this){
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if(SoundControl.instance == this){
            SoundControl.instance = null;
        }        
    }

    public void playHit(){
        audioSource.clip = hit;
        audioSource.Play();
    }

    public void playSalto(){
        audioSource.clip = salto;
        audioSource.Play();
    }

    public void playLlave(){
        audioSource.clip = llave;
        audioSource.Play();
    }
}
