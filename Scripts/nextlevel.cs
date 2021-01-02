
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using TMPro;

public class nextlevel : MonoBehaviour
{
   [SerializeField]public GameObject background;
    [SerializeField] public GameObject passedText;
    [SerializeField] public GameObject playAgain;
    [SerializeField] public GameObject nextLevel;
    Animator  stealanim;
     public string googleplayıd = "3691923";
    bool test = true;
    int level ;
    TextMeshProUGUI money_txt;
    int currentWealth;
    public bool stolen = false;
    bool nearCrown = false;
    public int stolenItems = 0;
    public AudioSource source;
    public AudioClip buttonclip;
    public AudioClip succes;
    
    void Start()
    {
        money_txt = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().money_txt;
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
        //Advertisement.Initialize(googleplayıd, test);
        background.SetActive(false);
        passedText.SetActive(false);
        playAgain.SetActive(false);
        nextLevel.SetActive(false);
        stealanim = GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>();
        level = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Char")
        {
            nearCrown = true;
            
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Char")
        {
            nearCrown = false;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(level);
        background.SetActive(false);
        passedText.SetActive(false);
        playAgain.SetActive(false);
        nextLevel.SetActive(false);
        currentWealth = PlayerPrefs.GetInt("Money");
        money_txt.text = "" + currentWealth.ToString();

        source.PlayOneShot(buttonclip);
        Time.timeScale =1;
    }
    public void NextLevel()
    {
        /* if (Advertisement.IsReady())
          {
              Advertisement.Show();
          }*/
        Time.timeScale =1;
        SceneManager.LoadSceneAsync(level+1);
        background.SetActive(false);
        passedText.SetActive(false);
        playAgain.SetActive(false);
        nextLevel.SetActive(false);
        source.PlayOneShot(buttonclip);
        currentWealth = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", currentWealth);
        
        money_txt.text = "" + currentWealth.ToString();
       
    }
   /* IEnumerator WaitForSeconds()
    {
       
        if (stealanim.GetCurrentAnimatorStateInfo(0).IsName("steal"))
        {
            background.SetActive(true);
            passedText.SetActive(true);
            playAgain.SetActive(true);
            nextLevel.SetActive(true);
        }
        yield return WaitForSeconds(); 
        
    }*/
    IEnumerator<WaitForSeconds> ToNextLevel()
    {
        //Print the time of when the function is first called.

        stealanim.Play("steal");
        PlayerPrefs.SetInt("Money", currentWealth);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        background.SetActive(true);
        passedText.SetActive(true);
        playAgain.SetActive(true);
        nextLevel.SetActive(true);
        //After we have waited 5 seconds print the time again.

    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().StealButton.Pressed && !stolen && nearCrown)
        {
            StartCoroutine(ToNextLevel());
            stolen = true;
            source.PlayOneShot(succes);
        }
    }

}
