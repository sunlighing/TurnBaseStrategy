using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float stoppingDistance = .1f;

    private Vector3 targetPosition;

    float moveSpeed = 4f;

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    } 

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
