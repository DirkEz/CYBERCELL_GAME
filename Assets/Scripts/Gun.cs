using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Animator anim;
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;
    public AudioSource source;
    public AudioClip ShootingClip;
    public AudioClip ReloadClip;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnDisable() => gunData.reloading = false;

    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf) {
            int num = UnityEngine.Random.Range(1, 3);
            if (num == 1)
            {
                anim.SetTrigger("ARReload");
                source.PlayOneShot(ReloadClip, 0.7f);
            }
            else if (num == 2)
            {
                anim.SetTrigger("ARReload_miss");
                source.PlayOneShot(ReloadClip, 0.7f);
            }
          
            
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }
                anim.SetTrigger("ARShoot");
                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                source.PlayOneShot(ShootingClip, 0.7f);
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
    }

    private void OnGunShot() { }
}