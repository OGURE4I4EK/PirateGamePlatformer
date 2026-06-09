using UnityEngine;

public class triggerP : MonoBehaviour
{
    public Rigidbody2D enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.simulated = true;
        }
    }
}
