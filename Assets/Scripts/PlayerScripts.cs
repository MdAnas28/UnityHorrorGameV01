using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScripts : MonoBehaviour
{
   [Header("Player Movement")]
    public float playerSpeed = 1.9f;

    [Header("Player Animator and Gravity")]
    public CharacterController cC;



    void Update()
    {
        playerMove();
    }




    void playerMove()
    {
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,targetAngle ,0f);
            cC.Move(direction.normalized * playerSpeed * Time.deltaTime);
        }


    }
}
