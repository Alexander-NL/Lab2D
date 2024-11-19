using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [Header("Ranged Attack")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float cooldownTimer = Mathf.Infinity;
    public float attackCooldown = 2f;
    public Transform player;
    public float despawnDistance = 15f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackCooldown)
        {
            RangeAttack();
        }

        cooldownTimer += Time.deltaTime;
    }

    void RangeAttack()
    {
        cooldownTimer = 0;
        GameObject bullet = Instantiate(bulletPrefab, player.position + new Vector3(1,0,0), player.rotation);

        Vector2 direction = Vector2.right;

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed;

        DespawnOnDistance despawnScript = bullet.AddComponent<DespawnOnDistance>();
        despawnScript.player = player;
        despawnScript.despawnDistance = despawnDistance;

        Destroy(bullet, 20f);
    }
}
