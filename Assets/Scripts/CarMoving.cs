using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMoving : MonoBehaviour
{
    private float movement;
    private JointMotor2D motor;
    private WheelJoint2D[] wheels;
    public Rigidbody2D car;
    public float speed = 1500f;
    public float carRotationSpeed = 10f;
    public float maxCarRotationSpeed = 100f;
    public float maxMotorTorque;

    private void Awake()
    {
        movement = 0f;
        motor = new JointMotor2D();
    }
    void Start()
    {
        motor.maxMotorTorque = maxMotorTorque;
        wheels = car.GetComponents<WheelJoint2D>();
    }
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (0f != movement)
        {
            wheels[0].useMotor = true;
            wheels[1].useMotor = true;

            motor.motorSpeed = -movement * speed;

            wheels[0].motor = motor;
            wheels[1].motor = motor;
        }

        else
        {
            wheels[0].useMotor = false;
            wheels[1].useMotor = false;
        }
        
        if(Mathf.Abs(car.angularVelocity) <= maxCarRotationSpeed)
        {
            car.AddTorque(movement * carRotationSpeed);
        }
    }
}
