using ScoreCount;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable {

    public float health;
    public TextAlignment scoreText;

    int score = 0;

    public void TakeDamage(float damage)
    {

        ScoreManager.instance.AddScore(1);

        //health -= damage;
        //if (health <= 0) Destroy(gameObject);
    }
}
