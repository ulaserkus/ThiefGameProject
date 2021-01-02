using DitzeGames.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class Open : MonoBehaviour
{
     Animation open;
    Animator anim;
    public GameObject Button;
    public bool opened = false;
    public bool interactable;
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponentInChildren<Animator>();
        // open = GameObject.FindGameObjectWithTag("dolap").GetComponent<Animation>();
        Button.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dolap")
        {
            interactable = true;
           Button.SetActive(true);
           
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "dolap")
        {
            interactable = false;
            Button.SetActive(false);
            opened = false;
        }
    }
    /*public void OpenIt()
    {
        if (!opened && interactable)
        {
            
            anim.Play("steal");
            open.Play("dolapOpen");
            opened = true;
        }
       
    }*/
}
