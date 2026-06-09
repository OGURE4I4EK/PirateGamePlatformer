using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveDirection
    {
        Horizontal,
        Vertical
    }

    [Header("Настройки движения")]
    public MoveDirection moveDirection = MoveDirection.Horizontal;
    public float distance = 3f;
    public float speed = 2f;
    public float waitTime = 0.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingToTarget = true;
    private bool isWaiting = false;

    private void Start()
    {
        startPosition = transform.position;

        if (moveDirection == MoveDirection.Horizontal)
            targetPosition = startPosition + Vector3.right * distance;
        else
            targetPosition = startPosition + Vector3.up * distance;
    }

    private void Update()
    {
        if (isWaiting) return;

        Vector3 destination = movingToTarget ? targetPosition : startPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destination,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            StartCoroutine(WaitAndSwitchDirection());
        }
    }

    private IEnumerator WaitAndSwitchDirection()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        movingToTarget = !movingToTarget;
        isWaiting = false;
    }
}