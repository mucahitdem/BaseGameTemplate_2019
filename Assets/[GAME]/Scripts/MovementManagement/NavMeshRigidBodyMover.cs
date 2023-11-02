using System;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.MovementManagement
{
    public class NavMeshRigidBodyMover : BaseMovement
    {
        private NavMeshAgent navMeshAgent;
        private Rigidbody rb;
        NavMeshHit hit;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
        }
        
        private void OnUpdate()
        {
            // Handle input or some other way to set the target position
            Vector3 targetPosition = GetTargetPosition(); // Replace this with your target position logic

            if (IsTargetPositionValid(targetPosition))
            {
                // Set the destination for the NavMeshAgent
                navMeshAgent.SetDestination(targetPosition);

                Vector3 moveDirection = (navMeshAgent.nextPosition - transform.position).normalized;
                rb.MovePosition(targetPosition);
            }
            else
            {
                // If the target position is not on the NavMesh, stop moving the Rigidbody
                rb.velocity = Vector3.zero;
            }
        }

        private bool IsTargetPositionValid(Vector3 targetPosition)
        {
            return NavMesh.SamplePosition(targetPosition, out hit, 1.0f, NavMesh.AllAreas);
        }
        private Vector3 GetTargetPosition()
        {
            // Replace this with your logic to obtain the target position
            // For example, you can use mouse clicks or other input methods.
            return Vector3.zero;
        }
    }
}