using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    //[SerializeField] private float _jumpforce;
    [SerializeField] private Rigidbody _rb;
    void Start()
    {

    }

    void Update()
    {

        Vector3 VelocityDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;

        _rb.velocity = -VelocityDirection;

        //VelocityDirection.y=_rb.velocity.y;

        //if (Input.GetKeyDown(KeyCode.Joystick1Button0))_rb.AddForce(Vector3.up * _jumpforce);
    }
}