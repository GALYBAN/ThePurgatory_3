using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public AudioSource source;

    public AudioClip coinSound;

    private BoxCollider2D boxCollider;

    void Awake()
    {
      source = GameObject.Find("sfxmanager").GetComponent<AudioSource>();
    }

 

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
        {
          //puntos.SumarPuntos(cantidadPuntos);
          //GameManager.Instance.ConseguirMoneda();
          Destroy(gameObject);
          source.PlayOneShot(coinSound);
          //GameManager.Instance.GanarMoneda();
        }
    
       
       
    

    }
}