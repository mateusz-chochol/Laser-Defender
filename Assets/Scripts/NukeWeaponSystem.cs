using System.Collections.Generic;
using UnityEngine;

public class NukeWeaponSystem : MonoBehaviour {

    public int damage = 35;

    //NukeRocketParticles
    public ParticleSystem nukeTrails;
    public ParticleSystem nukeWarhead;
    
    //NukeExplosionParticles
    public ParticleSystem explosionSmokeParticles;
    public ParticleSystem explosionFireParticles;
    public ParticleSystem explosionSparksParticles;

    //To instantiate explosion particles at the right place
    private List<ParticleCollisionEvent> collisionEvents;

    private void Start() {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    public void SendNuke() {
        nukeTrails.Emit(1);
        nukeWarhead.Emit(1);
        Debug.Log("Nuke");
    }

    private void OnParticleCollision(GameObject other) {
        ParticlePhysicsExtensions.GetCollisionEvents(nukeWarhead, other, collisionEvents);
        for (int i = 0; i < collisionEvents.Count; i++) {
            EmitAtLocation(collisionEvents[i]);
        }
        other.GetComponent<ObjectHealth>().TakeDamage(damage);
    }

    private void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent) {
        explosionSmokeParticles.transform.position = particleCollisionEvent.intersection;
        explosionSmokeParticles.Emit(8);
        explosionFireParticles.transform.position = particleCollisionEvent.intersection;
        explosionFireParticles.Emit(10);
        explosionSparksParticles.transform.position = particleCollisionEvent.intersection;
        explosionSparksParticles.Emit(10);
    }
}
