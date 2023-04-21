using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private FloatingJoystick joystick;

   [SerializeField] private float moveSpeed;

   [SerializeField] private float rotateSpeed;

   private Rigidbody myRigidbody;
   private Vector3 moveAxis;
   private Vector3 lastMoveAxis;
   private Vector3 savedDirection;
   private void Awake()
   {
      myRigidbody = GetComponent<Rigidbody>();
      lastMoveAxis = Vector3.zero;
   }

   private void Update()
   {
      Move();
   }

   private void Move()
   {
      
      moveAxis = Vector3.zero;
      moveAxis.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
      moveAxis.z = joystick.Vertical * moveSpeed * Time.deltaTime;
      if (joystick.Horizontal != 0 || joystick.Vertical != 0)
      {
         Vector3 direction = Vector3.RotateTowards(transform.forward, moveAxis, rotateSpeed * Time.deltaTime, 0.0f);
         transform.rotation = Quaternion.LookRotation(direction);
         lastMoveAxis.x = moveAxis.x;
         lastMoveAxis.z = moveAxis.z;
         myRigidbody.MovePosition(myRigidbody.position + moveAxis);
      }
      else if (lastMoveAxis == Vector3.zero)
      {
         myRigidbody.MovePosition(myRigidbody.position+Vector3.forward*Time.deltaTime*moveSpeed);
      }
      else
      {
         Vector3 direction = Vector3.RotateTowards(transform.forward, lastMoveAxis, rotateSpeed * Time.deltaTime, 0.0f);
         transform.rotation = Quaternion.LookRotation(direction);
         myRigidbody.MovePosition(myRigidbody.position + lastMoveAxis);
      }
      
      
   }
}
