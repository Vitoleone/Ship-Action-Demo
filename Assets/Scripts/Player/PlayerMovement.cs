using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] public FloatingJoystick joystick;

   [SerializeField] public float moveSpeed;

   [SerializeField] public float rotateSpeed;
   public bool isStoped = false;
   public bool isReady = true;

   private Rigidbody myRigidbody;
   private Vector3 moveAxis;
   private Vector3 lastMoveAxis;
   private Vector3 savedDirection;
   private void Awake()
   {
      myRigidbody = GetComponent<Rigidbody>();
      lastMoveAxis = Vector3.zero;
      
   }

   private void FixedUpdate()
   {
      Move();
   }

   private void Move()
   {
      moveAxis = Vector3.zero;
      if(joystick.gameObject.activeSelf)
      {
        moveAxis.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveAxis.z = joystick.Vertical * moveSpeed * Time.deltaTime;
      }
      else
      {
         moveAxis.x = 0;
         moveAxis.z = 0;
         lastMoveAxis = Vector3.zero;
      }

      if (isStoped == false && isReady == true)
      {
         if (joystick.Horizontal != 0 || joystick.Vertical != 0 && joystick.gameObject.activeSelf)
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
      else if(isReady == false && isStoped == false)
      {
         myRigidbody.MovePosition(myRigidbody.position+Vector3.forward*Time.deltaTime*moveSpeed);
         joystick.ResetValues();
      }
   }

   public void ResetSavedAxis()
   {
      lastMoveAxis = Vector3.zero;
      joystick.Direction.Set(0,0);
      moveAxis = Vector3.zero;
   }
}
