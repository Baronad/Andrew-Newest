using UnityEngine;

public class Target : MonoBehaviour
{

// assignar hur mycket liv moståndaren ska ha 
    public float health = 50f;

    public void TakeDamage (float amount)
    {
    
    // if health > 0% then die 
    
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }
}
