using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float rotateSpeed;
    public int rotateDirection;
    private bool isMoving;
    public float moveSpeed;
    private float moveTimer;
    private bool isReturn;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
        }
        if (isMoving)
        {
            if (!isReturn)
            {
                HookMove();
            }
            else
            {
                HookReturn();
            }
        }
        else
        {
            rotateHook();
        }
    }

    private void rotateHook()
    {
        float angle = (transform.eulerAngles.z + 180) % 360 - 180;
        if (angle >= 60)
        {
            rotateDirection = -1;
        } else if (angle <= -60)
        {
            rotateDirection = 1;
        }
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward * rotateDirection);
    }

    private void HookMove()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        moveTimer = moveTimer + Time.deltaTime;
        if (moveTimer >= 2)
        {
            isReturn = true;
        }
    }

    private void HookReturn()
    {
        transform.position = Vector3.MoveTowards(transform.position,originalPosition,moveSpeed * Time.deltaTime);
        if (transform.position.y >= originalPosition.y)
        {
            isMoving = false;
            isReturn = false;
            moveTimer = 0;
        }
    }
}
