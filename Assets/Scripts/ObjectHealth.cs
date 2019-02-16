using UnityEngine;

public class ObjectHealth : MonoBehaviour {

    public int startHealth = 100;
    private int health;

    private void Start() {
        health = startHealth;
    }

    public void TakeDamage(int damage) {
        if(health > 0) {
            health -= damage;
            if(health <= 0) {
                Die();
            }
        }
    }

    private void Die() {
        Debug.Log("Took " + startHealth + " damage. I'm dying!");
        DestroyObject(gameObject);
    }
}
