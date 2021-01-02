using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour
{
    Animation open;
    Animator anim;
    public GameObject Button;
    public bool opened = false;
    public bool neardoor;
    public AudioClip dooraudio;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<Animation>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor2();
        //CloseDoor();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            neardoor = true;
            Button.SetActive(true);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            neardoor = false;
            Button.SetActive(false);

        }
    }
    public void OpenDoor2()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().OpenButton.Pressed && !opened && neardoor)
        {
            anim.Play("steal");
            open.Play("openDoor2");
            opened = true;
            source.PlayOneShot(dooraudio);
            return;
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
