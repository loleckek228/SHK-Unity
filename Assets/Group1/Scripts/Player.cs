﻿using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;

    private float speedCoefficient = 2;
    private float accelerationTime = 2;
    private float speedAccelerationTime;
    private float speed;

    private void Start()
    {
        speed = _baseSpeed;
    }

    private void Update()
    {
        CheckAcceleration();
        Move();
    }

    private void Move()
    {
        transform.Translate(GetAxisSpeed("Horizontal"), GetAxisSpeed("Vertical"), 0);
    }

    private float GetAxisSpeed(string axis)
    {
        return Input.GetAxis(axis) * speed;
    }

    private void CheckAcceleration()
    {
        if (speedAccelerationTime > 0)
        {
            speedAccelerationTime -= Time.deltaTime;
            if (speedAccelerationTime <= 0)
            {
                speed /= speedCoefficient;
            }
        }
    }

    private void Acceleration()
    {
        speedAccelerationTime = accelerationTime;
        speed *= speedCoefficient;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Accelerator>())
        {
            Acceleration();
        }
    }
}