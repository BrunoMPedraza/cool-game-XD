using System;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Behavior : MonoBehaviour
{
    private Movement Movement;
    private void Awake()
    {
        Movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        Movement.Move();
    }
}