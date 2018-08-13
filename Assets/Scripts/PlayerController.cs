using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {



    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

         void Start()
    {

        motor = GetComponent<PlayerMotor>();

    }


         void Update()
    {

        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        // FINAL MOVEMENT

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        // APPLY MOVEMENT

        motor.Move(velocity);


        // ROTATION - > TURN AROUND 

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        // APPLY ROTATION

        motor.Rotate(rotation);
    }



}
