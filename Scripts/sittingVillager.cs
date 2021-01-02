using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sittingVillager : MonoBehaviour
{
    Animator animator;
    GameObject player;
    [SerializeField] public GameObject caution;
    [SerializeField] public GameObject vıllagerLook;
    public bool saw = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Char");
        animator.SetBool("sit", true);
        caution.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (saw)
        {
            animator.SetBool("sit", false);
            
        }
        else
        {
            //animator.SetBool("sit", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            gameObject.transform.LookAt(player.transform);
            caution.SetActive(true);
           

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            saw = false;
            caution.SetActive(false);
            gameObject.transform.LookAt(vıllagerLook.transform.right);
            
            
           // animator.SetBool("sit", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            saw = true;

        }
    }
}