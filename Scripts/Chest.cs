
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public bool nearchest;
    public Animation anim;
    Animator player;
    public bool opened = false;
    public Rigidbody TacPrefab;
    public Transform spawner;
     public GameObject Button;
    public int ItemNumber;
    public GameObject chest;
    public int currentWealth;
   
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        level = SceneManager.GetActiveScene().buildIndex;
        chest.SetActive(false);
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
    }

    // Update is called once per frame
    void Update()
    {
        InstantChest();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            nearchest = true;
            Button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            nearchest = false;
             Button.SetActive(false);
        }
    }
    IEnumerator<WaitForSeconds> Open()
    {
        //Print the time of when the function is first called.

        player.Play("steal");
        anim.Play();
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        
        Rigidbody TacInstance;
        TacInstance = Instantiate(TacPrefab, spawner.position, spawner.rotation) as Rigidbody; // Coini spawner pozisyonunda ve spawner rotasyonunda rigidbody olarak oluştur.
        TacInstance.AddForce(spawner.up * 200); // spawnerın yukarısına doğru fırlat


    }
    public void ChestOpen()
    {
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().OpenButton.Pressed && !opened && nearchest)
        {

            StartCoroutine(Open());

            opened = true;
        }
           

    }
    public void InstantChest()
    {
       
        ItemNumber = GameObject.FindGameObjectWithTag("crown").GetComponent<nextlevel>().stolenItems;
        if (level == 1)
        {
            if (ItemNumber >= 3)
            {
                chest.SetActive(true);
                ChestOpen();
            }
        }
       else if ( level == 2)
        {
            if (ItemNumber >= 4)
            {
                chest.SetActive(true);
                ChestOpen();
            }
        }
        else if (level == 3)
        {
            if (ItemNumber >= 4)
            {
                chest.SetActive(true);
                ChestOpen();
            }
        }
        else if (level == 4)
        {
            if (ItemNumber >= 5)
            {
                chest.SetActive(true);
                ChestOpen();
            }
        }
        else if (level == 5)
        {
            if (ItemNumber >= 5)
            {
                chest.SetActive(true);
                ChestOpen();
            }
        }
    }
}
