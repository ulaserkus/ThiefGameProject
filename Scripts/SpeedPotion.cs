using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public bool interactable = false;
    bool once = false;
    public float time = 10;
    public bool timeup = false;
    public bool Starttimer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       UsePot();
         Timer();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            interactable = false;
        }
    }
     public void UsePot()
    {
        if (interactable && GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().StealButton.Pressed && !once && !Starttimer)
        {
            once = true;
            Starttimer = true;

            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            
           
            
            
           
                
            
            
        }
               
           
           
           
            
        }
        
    
  public void Timer()
    {
        if (Starttimer)
        {
            if(time >0)
            {
                GameObject.FindGameObjectWithTag("Char").GetComponent<Player>().Speed = 8;
                time -= Time.deltaTime;
            }
            
            if (time <= 0)
            {
                GameObject.FindGameObjectWithTag("Char").GetComponent<Player>().Speed = 4;
            }
        }
        
    }
}
