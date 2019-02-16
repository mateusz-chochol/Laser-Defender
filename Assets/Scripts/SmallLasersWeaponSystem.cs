using UnityEngine;

public class SmallLasersWeaponSystem : MonoBehaviour {

    public ParticleSystem smallLasers;
    public int damage = 1;
    private ParticleSystem.EmissionModule emission;

    private void Start() {
        emission = smallLasers.emission;
    }

    public void Fire() {
        emission.enabled = true;
    }

    public void StopFiring() {
        emission.enabled = false;
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Target hit.");
        other.GetComponent<ObjectHealth>().TakeDamage(damage);
    }
}
