using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class necklace : MonoBehaviour
{
    Animator animator;
    public bool stolen = false;
    public bool nearobj = false;
    public GameObject Button;
    public int stolenItems = 0;
    public AudioClip stealaudio;
    public AudioSource source;
    public int currentWealth;
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        //Button.SetActive(false);
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
    }

    // Update is called once per frame
    void Update()
    {
        StealItem();
        /*if (nearobj)
        {
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            nearobj = true;
            //Button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            nearobj = false;
            // Button.SetActive(false);
        }
    }

    IEnumerator<WaitForSeconds> Steal()
    {
        //Print the time of when the function is first called.

        animator.Play("steal");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject, 0.5f);
        GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().GiveWealth(8);
        PlayerPrefs.SetInt("Money", currentWealth);
        GameObject.FindGameObjectWithTag("crown").GetComponent<nextlevel>().stolenItems++;
        //Button.SetActive(false);
        // stolen = false;
        //After we have waited 5 seconds print the time again.

    }
    public void StealItem()
    {
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().StealButton.Pressed && !stolen && nearobj)
        {
            StartCoroutine(Steal());
            source.PlayOneShot(stealaudio);
            stolen = true;

        }
    }
}
