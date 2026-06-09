using System.Collections;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    [Header("Поведение")]
    public bool chasePlayer = false;

    [Header("Патруль")]
    public float patrolDistance = 3f;
    public float moveSpeed = 2f;
    public float waitTime = 0.5f;

    [Header("Преследование")]
    public float detectionRadius = 5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingToTarget = true;
    private bool isWaiting = false;

    private Transform player;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.right * patrolDistance;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            player = playerObject.transform;
    }

    private void Update()
    {
        if (chasePlayer)
        {
            ChaseOnlyInRadius();
        }
        else
        {
            Patrol();
        }
    }

    private void ChaseOnlyInRadius()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Игрок не в радиусе — краб стоит
        if (distance > detectionRadius)
            return;

        float direction = Mathf.Sign(player.position.x - transform.position.x);

        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        Flip(direction);
    }

    private void Patrol()
    {
        if (isWaiting) return;

        Vector3 destination = movingToTarget ? targetPosition : startPosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            destination,
            moveSpeed * Time.deltaTime
        );

        Flip(destination.x - transform.position.x);

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

    private void Flip(float direction)
    {
        if (direction > 0)
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        else if (direction < 0)
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
    }

    private void OnDrawGizmosSelected()
    {
        if (chasePlayer)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}