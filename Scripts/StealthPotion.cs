using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StealthPotion : MonoBehaviour
{
    public bool interactable = false;
    bool once = false;
    public float time = 45;
    public bool timeup = false;
    public bool Starttimer = false;
    GameObject[] guards;
    // Start is called before the first frame update
    void Start()
    {
        guards = GameObject.FindGameObjectsWithTag("guard");
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

            if (time > 0)
            {
                foreach (GameObject guard in guards)
                {
                    guard.GetComponent<NPCController>().aggroRange = 3;

                }
              //  GameObject.FindGameObjectWithTag("Char").GetComponent<Player>().Speed = 8;
                time -= Time.deltaTime;
            }

            if (time <= 0)
            {
                foreach (GameObject guard in guards)
                {
                    guard.GetComponent<NPCController>().aggroRange = 10;
                }
                //GameObject.FindGameObjectWithTag("Char").GetComponent<Player>().Speed = 4;
            }
        }

    }
}
