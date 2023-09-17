using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Vector3 targetPosition;
    private float stoppingDistance = 1f;
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

    private void Update()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(targetPosition.x, targetPosition.z)) > stoppingDistance)
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
    }

    public List<GridPositon> GetValidActionGridPositionList()
    {
        List<GridPositon> validGridPostionList = new List<GridPositon>();
        
        return validGridPostionList;
    }
}
