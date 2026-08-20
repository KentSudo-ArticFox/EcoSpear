using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed = 1f;
    public float height = 0.15f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos +
            Vector3.up * Mathf.Sin(Time.time * speed) * height;
    }
}