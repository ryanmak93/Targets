using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Player : MonoBehaviour
{
    float vertRotation = 0;
    float vertvel = 0;

    public float movespeed = 5;
    public float rotatespeed = 8;
    public float vertical_lookrange = 70f;

    public float jumpspeed = 8f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        CharacterController charcontroller = GetComponent<CharacterController>();
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = !Cursor.visible;
            if (!Cursor.visible)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }        

        float sideRotation = Input.GetAxis("Mouse X") * rotatespeed;
        transform.Rotate(0, sideRotation , 0);

        vertRotation -= Input.GetAxis("Mouse Y") * rotatespeed;
        vertRotation = Mathf.Clamp(vertRotation, -vertical_lookrange, vertical_lookrange);                      

        Camera.main.transform.localRotation = Quaternion.Euler(vertRotation, 0, 0);

        float forwardSpeed = Input.GetAxis("Vertical") * movespeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movespeed;       

        vertvel += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && charcontroller.isGrounded)
        {
            vertvel = jumpspeed;
        }
        Vector3 speed;
        if(charcontroller.isGrounded)
            speed = new Vector3(sideSpeed, vertvel, forwardSpeed );
        else
            speed = new Vector3(sideSpeed/2, vertvel, forwardSpeed/2);
        speed = transform.rotation * speed;
        
        charcontroller.Move(speed * Time.deltaTime);
    }
}