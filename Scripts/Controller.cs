using DitzeGames.MobileJoystick;

using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    //Input
    protected Joystick Joystick;
    protected TouchField TouchField;
    protected Player Player;
    public Camera camera;
    //Parameters
    protected const float RotationSpeed = 15;

    //Camera Controll
    public Vector3 CameraPivot;
    public float CameraDistance;
    protected float InputRotationX;
    protected float InputRotationY;
    protected Button JumpButton;
    public Button StealButton;
    public Button OpenButton;
    public Button MarketButton;
    protected Button CarButton;
    protected Vector3 CharacterPivot;
    protected Vector3 LookDirection;
    public bool tps;
    public GameObject OpenB;
    // Use this for initialization
    void Start()
    {
        Joystick = FindObjectOfType<Joystick>();
        var buttons = new List<Button>(FindObjectsOfType<Button>());
        JumpButton = buttons.Find(b => b.gameObject.name == "JumpButton");
        OpenButton = buttons.Find(b => b.gameObject.name == "OpenButton");
        CarButton = buttons.Find(b => b.gameObject.name == "btnCar");
        StealButton = buttons.Find(b => b.gameObject.name == "StealButton");
        MarketButton = buttons.Find(b => b.gameObject.name == "MarketButton");
        TouchField = FindObjectOfType<TouchField>();
        Player = FindObjectOfType<Player>();
        camera = GetComponentInChildren<Camera>();
        TouchField.UseFixedUpdate = true;
        OpenB.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //input
        InputRotationX = InputRotationX + TouchField.TouchDist.x * RotationSpeed * Time.deltaTime % 360f;
        InputRotationY = Mathf.Clamp(InputRotationY - TouchField.TouchDist.y * RotationSpeed * Time.deltaTime, -88f, 88f);

        //left and forward
        var characterForward = Quaternion.AngleAxis(InputRotationX, Vector3.up) * Vector3.forward;
        var characterLeft = Quaternion.AngleAxis(InputRotationX + 90, Vector3.up) * Vector3.forward;

        //look and run direction
        var runDirection = characterForward * (Input.GetAxisRaw("Vertical") + Joystick.AxisNormalized.y) + characterLeft * (Input.GetAxisRaw("Horizontal") + Joystick.AxisNormalized.x);
        LookDirection = Quaternion.AngleAxis(InputRotationY, characterLeft) * characterForward;

        //set player values
        Player.Input.RunX = runDirection.x;
        Player.Input.RunZ = runDirection.z;
        Player.Input.LookX = LookDirection.x;
        Player.Input.LookZ = LookDirection.z;
        Player.Input.Jump = JumpButton.Pressed || Input.GetButton("Jump");

       /* if (OpenButton.Pressed)
        {
            Player.OpenDoor();
        }*/
        

        CharacterPivot = Quaternion.AngleAxis(InputRotationX, Vector3.up) * CameraPivot;
        if (GameObject.FindGameObjectWithTag("Char").GetComponent<Player>().Grounded == false)
        {
            CameraDistance = 0;
        }
    }
    
    private void LateUpdate()
    {
        //set camera values
        camera.transform.position = (transform.position + CharacterPivot) - LookDirection * CameraDistance;
        camera.transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);
    }
    public void ChangeCamera()
    {
        if (tps)
        {
            CameraDistance = 2;
            tps = !tps;

        }
        else if (!tps  )
        {
            CameraDistance = 0;
            tps = !tps;
        }

    }
}