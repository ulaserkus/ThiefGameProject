
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{    
    [SerializeField] public GameObject mainMenu;

  
    [SerializeField] public GameObject SaveQuit;
    [SerializeField] public GameObject MusıcOn;
    [SerializeField] public GameObject qualıtyoff;
    [SerializeField] public GameObject qualıtyon;
    [SerializeField] public GameObject MusıcOff;
    [SerializeField] public Button settingsBtn;

    public AudioClip clip;
    public AudioSource source;
    bool musıcon;
    int currentLevel;
    bool Interactable;
    bool Quality;
    int currentWealth;
    private AudioSource[] allAudioSources;
    private void Awake()
    {
        
        Interactable = true;
        Quality = true;
        musıcon = true;
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
        
    }
    void Start()
    {
        mainMenu.SetActive(false);
        SaveQuit.SetActive(false);
        MusıcOn.SetActive(false);
        qualıtyon.SetActive(false);
        qualıtyoff.SetActive(false);
        MusıcOff.SetActive(false);
        
        
    }

    void Update()
    {

        

       

    }
    public void settingsButon ()
    {
        
        
        if (Interactable == true)
        {
            source.PlayOneShot(clip);
            mainMenu.SetActive(true);
            SaveQuit.SetActive(true);
            MusıcOn.SetActive(true);
            settingsBtn.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 2.0f);
            //Time.timeScale = 0.0f;
            if (Quality == true)
            {
                qualıtyon.SetActive(false);
                qualıtyoff.SetActive(true);
            }else if (Quality==false)
            {
                qualıtyon.SetActive(true);
                qualıtyoff.SetActive(false);
            }
            if (musıcon == true)
            {
                MusıcOff.SetActive(false);
            }else if (musıcon == false)
            {
                MusıcOff.SetActive(true);

            }
            
            
            Interactable = false;

        }


          else if (Interactable == false)
          {
            source.PlayOneShot(clip);
            mainMenu.SetActive(false);
            SaveQuit.SetActive(false);
            MusıcOn.SetActive(false);
            qualıtyon.SetActive(false);
            qualıtyoff.SetActive(false);
            settingsBtn.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 2f);
            //Time.timeScale = 1.0f;
            
            Interactable = true;
          }
     }


    public void MainMenu()
    {

        SceneManager.LoadSceneAsync(0);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("continue", currentLevel);
        source.PlayOneShot(clip);
    }
    public void save()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("continue", currentLevel);
        PlayerPrefs.SetInt("Money", currentWealth);
        Application.Quit();
        source.PlayOneShot(clip);
    }

    
    public void highquality()
    {

        source.PlayOneShot(clip);
        qualıtyon.SetActive(false);
            qualıtyoff.SetActive(true);
        QualitySettings.SetQualityLevel(1);
        Quality = true;
          
     }

    public void lowquality()
    {
        qualıtyoff.SetActive(false);
        qualıtyon.SetActive(true);
        QualitySettings.SetQualityLevel(3);
        Quality = false;
        source.PlayOneShot(clip);
    }

    public void musicOn()
    {

        source.PlayOneShot(clip);
        MusıcOff.SetActive(true);
               allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
               foreach (AudioSource audioS in allAudioSources)
               {
                audioS.Stop();
                
               }

        musıcon = false;
    }

    public void musicOff()
    {
        source.PlayOneShot(clip);
        MusıcOff.SetActive(false);
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Play();

        }
        musıcon = true;
    }

}




