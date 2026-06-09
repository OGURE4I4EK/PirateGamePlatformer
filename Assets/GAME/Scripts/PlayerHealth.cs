using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Здоровье игрока")]
    public int maxHealth = 3;
    public int currentHealth;
    

    [Header("Неуязвимость после урона")]
    public float invulnerabilityTime = 1f;

    private bool isInvulnerable = false;

    private void Start()
    {
        currentHealth = maxHealth;
        UIHealth.instance.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int damage, ParticleSystem part)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        UIHealth.instance.UpdateHearts(currentHealth);
        Instantiate(part, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            GameManager.instance.LossGame();
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    private System.Collections.IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
    }
}