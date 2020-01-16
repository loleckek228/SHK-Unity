using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _fixedSpeed;

    private float accelerationTime;
    private float speed;
    private float speedCoefficient = 2;

    public event UnityAction OnAcceleration;

    private void Start()
    {
        OnAcceleration += OnPlayerAcceleration;
    }

    private void Update()
    {
        if (accelerationTime > 0)
        {
            accelerationTime -= Time.deltaTime;
        }
        else
        {
            speed = _fixedSpeed;
        }

        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontal, vertical, 0);
    }

    private void OnPlayerAcceleration()
    {
        speed *= speedCoefficient;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Accelerator>())
        {
            accelerationTime = speedCoefficient;
            OnAcceleration?.Invoke();
        }
    }
}