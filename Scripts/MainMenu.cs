

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioSource menu;
    int currentLevel;
    public Button contınue;
    public Button start;
    public Button exit;
    Animation startbuton;
    Animation continuebuton;
    Animation exitbuton;
    TextMeshProUGUI money_txt;
    int currentWealth;
    public AudioClip button;
    void Start()
    {
       menu=gameObject.GetComponent<AudioSource>();
       continuebuton=contınue.GetComponent<Animation>();
       startbuton=start.GetComponent<Animation>();
       exitbuton=exit.GetComponent<Animation>();
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
        money_txt = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().money_txt;
        menu.Play();
        
    }

    
   
    public void StartButton()
    {
        startbuton.Play();
     //  StartCoroutine(waitstart());
        SceneManager.LoadScene("scene");
        menu.Stop();
        menu.PlayOneShot(button);

    }

    public void ExitGame()
    {
        exitbuton.Play();
     
        menu.PlayOneShot(button);
        Application.Quit();
    }

  
    public void Continue()
    {
        continuebuton.Play();
       
        menu.PlayOneShot(button);
        int scene = PlayerPrefs.GetInt("continue");
        SceneManager.LoadSceneAsync(scene);
        currentWealth = PlayerPrefs.GetInt("Money");
        money_txt.text = "" + currentWealth.ToString();
        menu.Stop();
    }

    

    

   
 


}
