
using UnityEngine;

public class milk : MonoBehaviour
{
     public Animator anim;
    public AudioClip clip;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("milk");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            source.PlayOneShot(clip);
        }
    }
}
