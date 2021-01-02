using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public InputStr Input;
    public struct InputStr
    {
        public float LookX;
        public float LookZ;
        public float RunX;
        public float RunZ;
        public bool Jump;
    }
    Animation open;
    Animator anim;
    public  float Speed = 10f;
    public  float JumpForce = 5f;
    public bool Grounded;
    protected Rigidbody Rigidbody;
    protected Quaternion LookRotation;
    public AudioSource source;
    public AudioClip Jumpclip;
    public AudioClip Musicclip;
    private void Awake()
    {
       // open = GameObject.FindGameObjectWithTag("dolap").GetComponent<Animation>();
        Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        source.PlayOneShot(Musicclip);
    }
    private void Update()
    {
       
        
    }
    void FixedUpdate()
    {

        var inputRun = Vector3.ClampMagnitude(new Vector3(Input.RunX, 0, Input.RunZ), 1);
        var inputLook = Vector3.ClampMagnitude(new Vector3(Input.LookX, 0, Input.LookZ), 1);

        Rigidbody.velocity = new Vector3(inputRun.x * Speed, Rigidbody.velocity.y, inputRun.z * Speed);

        //rotation to go target
        if (inputLook.magnitude > 0.01f)
            LookRotation = Quaternion.AngleAxis(Vector3.SignedAngle(Vector3.forward, inputLook, Vector3.up), Vector3.up);

        transform.rotation = LookRotation;
        
        if (Input.Jump && Grounded)
        {

            
            source.PlayOneShot(Jumpclip);
             anim.Play("Jump");
             Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, JumpForce, Rigidbody.velocity.z);
            
        }
        else
        {
            source.volume = 1;
        }
        // var Grounded = Physics.OverlapSphere(transform.position, 0.5f, 1).Length > 1;
        anim.SetBool("Grounded", Grounded);
        var localVelocity = Quaternion.Inverse(transform.rotation) * (Rigidbody.velocity / Speed);
        anim.SetFloat("PosX", localVelocity.x);
        anim.SetFloat("PosY", localVelocity.z);
    }
    private void LateUpdate()
    {
        anim.transform.localPosition = Vector3.zero;
        anim.transform.localRotation = Quaternion.identity;
    }
    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "floor")
        {
           Grounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "floor")
        {
            Grounded = false;
        }
    }
   /* public void OpenDoor()
    {
        anim.Play("steal");
        open.Play("dolapOpen");
    }*/
}