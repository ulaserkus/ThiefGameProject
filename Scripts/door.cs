using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
public class door : MonoBehaviour
{
   Animation open;
    Animator anim;
    public GameObject Button;
    public bool opened = false;
    public bool neardoor;
    public AudioClip dooraudio;
    public AudioSource source;
    Button openButton;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        open = gameObject.GetComponent<Animation>();
        openButton = GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().OpenButton;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
        //CloseDoor();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Char")
        {
            neardoor = true;
            Button.SetActive(true);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Char")
        {
            neardoor = false;
            Button.SetActive(false);
            
        }
    }
    public void OpenDoor()
    {
        if (openButton.Pressed && !opened && neardoor)
        {
            anim.Play("steal");
            open.Play();
            opened = true;
            source.PlayOneShot(dooraudio);
        }
    }
   /* public void CloseDoor()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().OpenButton.Pressed && opened && neardoor)
        {
            anim.Play("steal");
            open.Play("closeDoor");
            opened = false;
        }
    }*/
    
}
