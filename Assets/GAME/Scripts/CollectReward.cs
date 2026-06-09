using UnityEngine;

public class CollectReward : MonoBehaviour
{
    public int rewardValue = 1;
    public ParticleSystem particleReward;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.AddScore(rewardValue);
            Instantiate(particleReward, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
