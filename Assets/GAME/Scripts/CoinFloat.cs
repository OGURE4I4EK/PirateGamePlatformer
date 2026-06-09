using System;
using UnityEngine;

public class CoinFloat : MonoBehaviour
{
    [Header("Плавание вверх-вниз")]
    public float amplitude = 0.25f;
    public float speed = 2f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + yOffset,
            startPosition.z
        );
    }
}