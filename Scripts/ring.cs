using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    Animator animator;
    public bool stolen = false;
    public bool nearobj = false;
    public GameObject Button;
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
        if (other.tag == "Char")
        {
            nearobj = true;
            //Button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Char")
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
        GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().GiveWealth(6);
        GameObject.FindGameObjectWithTag("crown").GetComponent<nextlevel>().stolenItems++;
        PlayerPrefs.SetInt("Money", currentWealth);
        //Button.SetActive(false);
        // stolen = false;
        //After we have waited 5 seconds print the time again.

    }
    public void StealItem()
    {
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().StealButton.Pressed && !stolen && nearobj)
        {
            StartCoroutine(Steal());

            stolen = true;
            source.PlayOneShot(stealaudio);
        }
    }
}
