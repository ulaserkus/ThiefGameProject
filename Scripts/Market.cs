using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Market : MonoBehaviour
{
    public GameObject Marketcanvas;
    public GameObject HealthpotButton;
    public GameObject SpeedpotButton;
    public GameObject StealthpotButton;
    public GameObject closeButton;
    public GameObject openButton;
    public  bool Interactable = false;
    public Transform spawner;
    public Rigidbody HealthPot;
    public Rigidbody SpeedPot;
    public Rigidbody StealthPot;
    public GameObject infocanvas;
    public bool  canPurchase;
    public TMPro.TextMeshProUGUI timerText;
    public float timeRemaining;
    public GameObject timerCanvas;
   
    public bool presstobuy = false;
    public bool counting;
    public bool buyclose;
    public int RedCost = 20;
    void Start()
    {
       timeRemaining = 5;
        openButton.SetActive(false);
        Marketcanvas.SetActive(false);
    }
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Char"))
        {
            Interactable = true;

            openButton.SetActive(true);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {


        if (other.CompareTag("Char"))
        {
            Interactable = false;
            Marketcanvas.SetActive(false);
            openButton.SetActive(false);
        }
    }
  
    public void HealhtButton()
    {
        if (Interactable  && GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth >= RedCost)
        {
            Rigidbody PotInstance;
            
            PotInstance = Instantiate(HealthPot, spawner.position, spawner.rotation) as Rigidbody; // Coini spawner pozisyonunda ve spawner rotasyonunda rigidbody olarak oluştur.
            PotInstance.AddForce(spawner.up ); // spawnerın yukarısına doğru fırlat
            GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().LoseMoney(20);

            HealthpotButton.SetActive(false);

           
            
            

        }
       

    }

   /* void infobutton()
    {
        if (Interactable)
        {
            infocanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                infocanvas.SetActive(false);
                Interactable = false;
            }
        }


    }*/
   
    public void CloseMarket()
    {
        if (Interactable)
        {
            GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled = true;
            Marketcanvas.SetActive(false);
            
            
           
        }
        
    }
    public void OpenMarket()
    {
        if( Interactable)
        {
            Marketcanvas.SetActive(true);
            GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled =false;
            
        }
    }
    public void SpeedButton()
    {
        if (Interactable && GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth >=40)
        {
            Rigidbody PotInstance;

            PotInstance = Instantiate(SpeedPot, spawner.position, spawner.rotation) as Rigidbody; // Coini spawner pozisyonunda ve spawner rotasyonunda rigidbody olarak oluştur.
            PotInstance.AddForce(spawner.up); // spawnerın yukarısına doğru fırlat
            GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().LoseMoney(40);

           SpeedpotButton.SetActive(false);





        }


    }
    public void StealthButton()
    {
        if (Interactable && GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth >= 50)
        {
            Rigidbody PotInstance;

            PotInstance = Instantiate(StealthPot, spawner.position, spawner.rotation) as Rigidbody; // Coini spawner pozisyonunda ve spawner rotasyonunda rigidbody olarak oluştur.
            PotInstance.AddForce(spawner.up); // spawnerın yukarısına doğru fırlat
            GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().LoseMoney(50);

           StealthpotButton.SetActive(false);

        }
    }


}
