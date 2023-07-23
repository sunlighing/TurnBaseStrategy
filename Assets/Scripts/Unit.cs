using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float stoppingDistance = 1f;

    private Vector3 targetPosition;

    float moveSpeed = 4f;

    float rotateSpeed = 15f;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition.x = targetPosition.x;
        this.targetPosition.z = targetPosition.z;
    } 

    // Update is called once per frame
    void Update()
    {
       
        if (Vector2.Distance( new Vector2(transform.position.x , transform.position.z), new Vector2(targetPosition.x, targetPosition.z) ) > stoppingDistance )
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

       /// if (Input.GetMouseButtonDown(0))
       // {
      //      Move(MouseWorld.GetPosition());
       // }
    }
}
