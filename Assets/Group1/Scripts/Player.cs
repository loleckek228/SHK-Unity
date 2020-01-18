using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;

    private float speedCoefficient = 2;
    private float accelerationTime = 2;
    private float speedAccelerationTime;
    private float speed;

    private void Update()
    {
        if (speedAccelerationTime > 0)
        {
            speedAccelerationTime -= Time.deltaTime;
        }
        else
        {
            speed = _baseSpeed;
        }

        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontal, vertical, 0);
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