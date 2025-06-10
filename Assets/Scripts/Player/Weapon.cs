using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;
    AudioSource shootSound;
    WeaponSO weaponSO;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        this.weaponSO = weaponSO;
        OnShoot();

    }

    public void OnShoot()
    {
        RaycastHit hit;
        muzzleFlash.Play();
        shootSound.Play();
        impulseSource.GenerateImpulse();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {

            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }

    }

}

