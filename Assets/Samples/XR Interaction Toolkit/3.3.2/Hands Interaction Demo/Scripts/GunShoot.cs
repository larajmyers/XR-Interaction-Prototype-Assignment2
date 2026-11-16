
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public InputActionProperty shootAction;

    public float bulletSpeed = 15f;
    public float fireRate = 0.3f;

    private float nextFireTime;

    void OnEnable()
    {
        shootAction.action?.Enable();
    }

    void OnDisable()
    {
        shootAction.action?.Disable();
    }

    void Update()
    {
        if (shootAction.action != null &&
            shootAction.action.WasPressedThisFrame() &&
            Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.right * bulletSpeed;

        Destroy(bullet, 3f);
    }
}

