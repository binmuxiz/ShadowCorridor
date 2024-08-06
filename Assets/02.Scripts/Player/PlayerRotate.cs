using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float moveSpeed = 7f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        dir = Camera.main.transform.TransformDirection(dir);
    }
}
