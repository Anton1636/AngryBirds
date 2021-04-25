using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 rotationCamera = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    public void RotateCam(Vector3 cam)
    {
        rotationCamera = cam;
    }

    private void FixedUpdate()
    {
        PerformMove();
        PerformRotation();
    }   

    private void PerformMove()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
       // rb.MovePosition(rb.rotation * Quaternion.Euler(rotation));

        if(cam != null)
        {
            cam.transform.Rotate(-rotationCamera);
        }
    }
}
