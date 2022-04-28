using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfo;
    public float maxMotorTorque = 400;
    public float maxSteeringAngle = 30;

    // Input Variables
    private float steeringAxis;
    private float motorAxis;

    /// <summary>
    /// Sets the transform and potision of the wheel model based on the pose
    /// of the WheelCollider.
    /// 
    /// (Commented out due to position issues with the pose.)
    /// </summary>
    /// <param name="collider"></param>
    /// <param name="wheelVisual"></param>
    /*public void SetWheelVisuals(WheelCollider collider, Transform wheelVisual)
    {
        Vector3 wheelPosition;
        Quaternion wheelRotation;
        collider.GetWorldPose(out wheelPosition, out wheelRotation);

        wheelVisual.position = wheelPosition;
        wheelVisual.rotation = wheelRotation;
    }*/

    public void FixedUpdate()
    {
        steeringAxis = Input.GetAxis("Horizontal");
        motorAxis = Input.GetAxis("Vertical");

        float motor = maxMotorTorque * motorAxis;
        float steering = maxSteeringAngle * steeringAxis;

        /*
         * Set the steering and motor values for each wheel collider
         * based on the input
         */
        foreach (AxleInfo axle in axleInfo)
        {
            if (axle.steering)
            {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
            if (axle.motor)
            {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor; 
            }

            //SetWheelVisuals(axle.leftWheel, axle.leftWheelVisual);
            //SetWheelVisuals(axle.rightWheel, axle.rightWheelVisual);
        }
    }
}

// Set in inspector
[System.Serializable]
public class AxleInfo
{
    public WheelCollider rightWheel;
    public WheelCollider leftWheel;
    public Transform rightWheelVisual;
    public Transform leftWheelVisual;
    // Enable these depending on the what the axle is used for.
    public bool motor;
    public bool steering;
}
