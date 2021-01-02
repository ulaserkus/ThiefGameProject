using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;
public class dolap : MonoBehaviour
{
    Animation open;
    Animator anim;
    public GameObject Button;
    public bool opened = false;
    public bool neardolap;
    bool canClose = false;
    public AudioSource source;
    public AudioClip dolapClip;
    Button openButton;
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<Animation>();
        anim = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        openButton = GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().OpenButton;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDolap();
        //CloseDolap();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Char")
        {
            neardolap = true;
            Button.SetActive(true);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Char")
        {
            neardolap = false;
            Button.SetActive(false);
           
        }
    }
    public void OpenDolap()
    {
        if (openButton.Pressed && !opened && neardolap)
        {
            anim.Play("steal");
            open.Play("dolapOpen");
            opened = true;
            source.PlayOneShot(dolapClip);
        }
    }
    /*public void CloseDolap()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().OpenButton.Pressed && opened && neardolap )
        {
            anim.Play("steal");
            open.Play("dolapClose");
            opened = false;
        }
    }*/
}
