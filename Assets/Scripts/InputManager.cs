using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool upPressed = false;
    private bool downPressed = false;
    private bool leftPressed = false;
    private bool rightPressed = false;

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        Direction();
    }

    public Vector3 Direction()
    {
        Vector3 direction = Vector3.zero;

        if (upPressed) direction += Vector3.forward;
        if (downPressed) direction += Vector3.back;
        if (leftPressed) direction += Vector3.left;
        if (rightPressed) direction += Vector3.right;

        return direction;
    }

    public void OnUpPressed() => upPressed = true;
    public void OnUpReleased() => upPressed = false;

    public void OnDownPressed() => downPressed = true;
    public void OnDownReleased() => downPressed = false;

    public void OnLeftPressed() => leftPressed = true;
    public void OnLeftReleased() => leftPressed = false;

    public void OnRightPressed() => rightPressed = true;
    public void OnRightReleased() => rightPressed = false;
}
