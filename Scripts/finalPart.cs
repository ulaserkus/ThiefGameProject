using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class finalPart : MonoBehaviour
{

    public string GameId = "xxxxxx";
    public bool testMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GameId, testMode);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void support()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        // reklam eklenecek
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
