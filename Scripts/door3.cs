
using UnityEngine;

public class door3 : MonoBehaviour
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
        OpenDoor3();
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
    public void OpenDoor3()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().OpenButton.Pressed && !opened && neardoor)
        {
            anim.Play("steal");
            open.Play("doorOpen3");
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
