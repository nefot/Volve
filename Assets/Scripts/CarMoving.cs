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
    [Range(0, 10)]
    public int level;
    public float max_add_speed = 250f;
    public PhysicsMaterial2D wheelMaterial;
    public float start_friction = 1f;
    public float max_add_friction = 2f;
    private bool fuel = false;

    private void Awake()
    {
       
        movement = 0f;
        motor = new JointMotor2D();
        wheelMaterial.friction = start_friction + (max_add_friction * level / 10f);
        speed += (max_add_speed * level / 10f);
        
       
    }
    void Start()
    {
        fuel = GameObject.FindGameObjectWithTag("GameController").GetComponent<FuelBar>().Fuel;
        motor.maxMotorTorque = maxMotorTorque;
        wheels = car.GetComponents<WheelJoint2D>();
    }
    void Update()
    {
        fuel = GameObject.FindGameObjectWithTag("GameController").GetComponent<FuelBar>().Fuel;
        movement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
        {
        if (fuel == true)
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

            if (Mathf.Abs(car.angularVelocity) <= maxCarRotationSpeed)
            {
                car.AddTorque(movement * carRotationSpeed);
            }
        }
        else
        {
            wheels[0].useMotor = false;
            wheels[1].useMotor = false;
        }
    }
}
