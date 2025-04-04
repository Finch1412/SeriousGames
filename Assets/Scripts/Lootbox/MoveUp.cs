using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveSpeed = 0.3f; // Units per second
    private float timer = 0f;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            // Move the object up
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Update the timer
            timer += Time.deltaTime;

            // Stop after 3 seconds
            if (timer >= 1.5f)
            {
                isMoving = false;
            }
        }
    }
}
