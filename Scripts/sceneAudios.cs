using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneAudios : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
