//using Boo.Lang;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float patrolTime = 15; // time in seconds to wait before seeking a new patrol destination
    public float aggroRange = 10; // distance in scene units below which the NPC will increase speed and seek the player
    public Transform[] waypoints; // collection of waypoints which define a patrol area
   
    int index; // the current waypoint index in the waypoints array
    float speed, agentSpeed; // current agent speed and NavMeshAgent component speed
    Transform player; // reference to the player object transform
    public AudioSource source;
    public AudioClip gethit;

    public Animator animator; // reference to the animator component
    NavMeshAgent agent; // reference to the NavMeshAgent
    
    [Header("Use for Debugging Aggro Radius")] // seçenek baþlýðý oluþturma
    public bool showAggro = true;
    public bool hit;
    bool onsaw;
    void Awake()
    {
        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) { agentSpeed = agent.speed; }
        player = GameObject.FindGameObjectWithTag("Char").transform;
        index = Random.Range(0, waypoints.Length);
        

        animator.SetBool("Walk", true);
        animator.SetBool("Running", false);
        InvokeRepeating("Tick", 0, 0.5f);
        if (waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", Random.RandomRange(0, patrolTime),patrolTime);
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
        }
       /* GameObject[] villagers;
        villagers = GameObject.FindGameObjectsWithTag("Výllager");
        foreach (GameObject go in villagers)
        {
           onsaw = GetComponent<villager2>().saw;
        }
       // onsaw = GameObject.FindGameObjectsWithTag("Výllager").GetComponent<villager2>().saw;*/
        
    }
    private void Start()
    {
        
    }

    void Patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;

    }
    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2; //baþlangýç hýzý maks hýzýnýn yarýsý

        if (player != null && Vector3.Distance(transform.position,player.position) < aggroRange) // player var ve aggroRange den yakýnsa
        {
            agent.destination = player.position;  //playerýn konumuna git
            agent.speed = agentSpeed ;  // hýzý maks hýza eþitle
            animator.SetBool("Walk", false);
            animator.SetBool("Running", true);
            gameObject.transform.LookAt(player.transform );
            if (player != null && Vector3.Distance(transform.position, player.position) <= 1.3f  )
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Running", false);
                

                if (hit)
                {
                   
                   // animator.Play("sword");
                    hit = false;
                    GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled = false;
                    StartCoroutine(GetHit());
                    
                    /* if ( GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealht>().currentHealht <= 25)
                     {
                         StartCoroutine(GetHit());
                         StartCoroutine(Die());
                     }*/

                    //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().Play("GetHit");

                }
               
                
            }
            else if (      player != null && Vector3.Distance(transform.position, player.position) > 2f && player != null && Vector3.Distance(transform.position, player.position) < aggroRange )
            {
                hit = true;
            }

        }
        
        else
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
            hit = true;
        }

    }
    private void OnDrawGizmos()
    {
        if (showAggro)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, aggroRange); // sphere þeklinde menzil belirt.
        }
    }
    IEnumerator<WaitForSeconds> GetHit()
    {
        //Print the time of when the function is first called.

        animator.Play("sword");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.2f);
        GameObject.FindGameObjectWithTag("Char").GetComponentInChildren<Animator>().Play("GetHit");
        GameObject.FindGameObjectWithTag("Char").GetComponent<PlayerHealht>().LoseHealht();
        source.PlayOneShot(gethit);
        GameObject.FindGameObjectWithTag("Char").GetComponent<Controller>().enabled = true;
        // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealht>().LoseHealht();
        //After we have waited 5 seconds print the time again.

    }
    /* IEnumerator<WaitForSeconds> Die()
     {
         StartCoroutine(GetHit());
         yield return new WaitForSeconds(1.2f);
         GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().Play("Dying");
         GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().center = new Vector3(0, 1.584742f, 0);
     }*/
    private void Update()
    {

        /*if (onsaw && player != null && Vector3.Distance(transform.position, player.position) > aggroRange )
        {
            
            agent.destination = player.position;
            agent.speed = agentSpeed /2f;
        }*/
      
    }
}
