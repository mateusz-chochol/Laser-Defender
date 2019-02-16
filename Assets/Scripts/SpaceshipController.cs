using System.Collections;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    public static SpaceshipController playerInstance;
    public NukeWeaponSystem nukes;
    public int maxAmmo = 2;
    private int currentAmmo;
    public SmallLasersWeaponSystem smallLasers;
    private Vector3 desiredPosition;
    private float cooldownEffect = 0;
    private float reloadTime = 8f;

    private void Start() {
        currentAmmo = maxAmmo;
    }

    private void Update() {
        SpaceshipMovement();
        SpaceshipRotation();
        Attacks();
    }

    private void SpaceshipMovement() {
        Ray positionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(positionRay, out hitInfo, 1 << 8)) {
            desiredPosition = new Vector3(hitInfo.point.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5);
        }
    }

    private void SpaceshipRotation() {
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Clamp((transform.position.x - desiredPosition.x) / 10, -0.5f, 0.5f), transform.rotation.w), Time.deltaTime * 2);
    }

    private void Attacks() {
        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(0)) {

            if (cooldownEffect <= Time.time) {
                nukes.SendNuke();
                currentAmmo--;

                if (currentAmmo == 0) {
                    StopAllCoroutines();
                    cooldownEffect = Time.time + reloadTime;
                    currentAmmo = maxAmmo;
                }
                else {
                    StartCoroutine(ReloadOneRocket());
                }
            }            
        }

        if (Input.GetMouseButtonDown(0)) {
            smallLasers.Fire();
        }

        else if (Input.GetMouseButtonUp(0)) {
            smallLasers.StopFiring();
        }
    }

    IEnumerator ReloadOneRocket() {
        yield return new WaitForSeconds(3f);
        currentAmmo += 1;
        if(currentAmmo != maxAmmo) {
            StartCoroutine(ReloadOneRocket());
        }
    }
}
