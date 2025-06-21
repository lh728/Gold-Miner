using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float roateSpeed;
    public int rotateDirection;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.Rotate(roateSpeed * Time.deltaTime * Vector3.forward * rotateDirection);
    }

    private void HookMove()
    {
        transform.Translate
    }
}
