
using UnityEngine;

public class villager : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Plant", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
