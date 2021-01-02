using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public bool interactable = false;
    bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UsePot();
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
            interactable = false ;
        }
    }
    void UsePot()
    {
        if(interactable && GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().StealButton.Pressed && !once)
        {
            once = true;
            GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentHealht += 25;
            GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().healht_txt.text = "%" + GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentHealht.ToString();
            Destroy(gameObject);
        }
    }
}
