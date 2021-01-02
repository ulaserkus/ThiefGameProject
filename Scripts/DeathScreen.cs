
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


using TMPro;
public class DeathScreen : MonoBehaviour
{
    int thisLevel;
    [SerializeField] public GameObject GameOver;
    [SerializeField] public GameObject Exit;
    [SerializeField] public GameObject TryAgainButon;
    [SerializeField] public GameObject watchAds;


    public string GooglePlayId = "3691923";
    TextMeshProUGUI money_txt;
    float currentWealth;
    string myPlacementId = "rewardedVideo";
    public bool testMode = true;
    public AudioSource source;
    public AudioClip buttonclip;
    public AudioClip gameOver;
    void Start()
    {
        currentWealth = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentWealth;
        money_txt = GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().money_txt;
        Advertisement.Initialize(GooglePlayId, testMode);
        GameOver.SetActive(false);
        Exit.SetActive(false);
        TryAgainButon.SetActive(false);
        watchAds.SetActive(false);
        
       

    }
    public void exit()
    {
        GameOver.SetActive(false);
        Exit.SetActive(false);
        TryAgainButon.SetActive(false);
       watchAds.SetActive(false);
       
        thisLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("continue", thisLevel);
        Application.Quit();
        source.PlayOneShot(buttonclip);

    }
   public void Ads()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(myPlacementId);
        }

        source.PlayOneShot(buttonclip);
    }

   

    public void TryAgain()
    {
        source.PlayOneShot(buttonclip);
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions() { resultCallback = OnUnityAdsDidFinish };
            Advertisement.Show();
        }
        currentWealth = PlayerPrefs.GetInt("Money");
        money_txt.text = "" + currentWealth.ToString();

        GameOver.SetActive(false);
        Exit.SetActive(false);
        TryAgainButon.SetActive(false);
        watchAds.SetActive(false);
        thisLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(thisLevel);
        GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled =true;


    }

    void Update()
    {
        OnDeath();
        
    }


    public void OnUnityAdsDidFinish(ShowResult showResult)
    {
        
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealht>().currentWealth += 20;
            money_txt.text = "" + currentWealth.ToString();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
          
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
        if (placementId == myPlacementId)
        {
           
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    public void OnDeath()
    {
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().currentHealht <= 0)
        {
            GameOver.SetActive(true);
            Exit.SetActive(true);
            TryAgainButon.SetActive(true);
            watchAds.SetActive(true);
            source.PlayOneShot(gameOver);
            GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled = false;
            GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>().Play("Stun");
            GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().CameraDistance = 2;
        }

    }



}






