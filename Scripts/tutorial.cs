using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
   public GameObject prestart;
    public AudioSource source;
    public AudioClip buton;

    
    void Start()
    {
        prestart.SetActive(true);
        Time.timeScale = 0;
    
    }

    
    public void close()
    {
        prestart.SetActive(false);
        source.PlayOneShot(buton);
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
}
