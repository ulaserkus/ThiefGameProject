
using UnityEngine;
using UnityEngine.AI;

public class villager2 : MonoBehaviour
{
    public float patrolTime = 15; // time in seconds to wait before seeking a new patrol destination

    public Transform[] waypoints; // collection of waypoints which define a patrol area

    int index; // the current waypoint index in the waypoints array
    float  agentSpeed; // current agent speed and NavMeshAgent component speed
    Transform trans; // reference to the player object transform
    public AudioClip male;
    public AudioSource source;

    public Animator animator; // reference to the animator component
    NavMeshAgent agent; // reference to the NavMeshAgent
    [SerializeField] public GameObject caution;
    GameObject player;
    GameObject Vıllager;
    [SerializeField] public GameObject vıllagerLook;
    public bool saw=false;
    void Awake()
    {

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) { agentSpeed = agent.speed; }
        trans = GameObject.FindGameObjectWithTag("Char").transform;
        index = Random.Range(0, waypoints.Length);


        animator.SetBool("walk", true);

        if (waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", Random.RandomRange(0, patrolTime), patrolTime);
            animator.SetBool("walk", true);
           
        }
       

    }
    void Start()
    {
       player= GameObject.FindGameObjectWithTag("Char");
       Vıllager= GameObject.FindGameObjectWithTag("Vıllager");

        caution.SetActive(false);
    }
    private void FixedUpdate()
    {

        Alert(); 

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            gameObject.transform.LookAt(player.transform);
            caution.SetActive(true);
            animator.SetBool("walk", false);
            GameObject.FindGameObjectWithTag("guard").GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Char"))
        {
            caution.SetActive(false);
            gameObject.transform.LookAt(vıllagerLook.transform.forward);
            animator.SetBool("walk", true);
            saw = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Char"))
        {
            saw = true;
           // source.volume = 0.5f;
           
            source.PlayOneShot(male);
        }
    }
     public void Alert()
    {
        if (!saw)
        {

            agent.destination = waypoints[index].position;
            agent.speed = agentSpeed / 2;
        }
        else
        {
            gameObject.transform.LookAt(player.transform);
            agent.destination = gameObject.transform.position;
            animator.SetBool("walk", false);
        }
    }








    void Patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
        
    }
    

        

}
