using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Настройки урона")]
    public int damage = 1;

    [Header("Эффекты")]
    public ParticleSystem hitParticle;

    [Header("Поведение")]
    public bool destroyAfterHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage, hitParticle);

                if (destroyAfterHit)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}