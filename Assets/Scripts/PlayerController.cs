using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    private Rigidbody rig;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 1f;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(InputManager.Instance.Direction());
    }
    
    private void Move(Vector3 direction)
    {
        Vector3 newVelocity = direction.normalized * moveSpeed;
        newVelocity.y = rig.velocity.y;
        rig.velocity = newVelocity;

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            rig.MoveRotation(Quaternion.Lerp(rig.rotation, toRotation, moveSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TheVoid"))
        {
            GameManager.Instance.LostLevel();
        }
    }
}
