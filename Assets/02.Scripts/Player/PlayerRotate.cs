using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotationSpeed = 200f;

    private float mx = 0f;
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        mx += mouseX * rotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0f, mx, 0f);
    }
}
