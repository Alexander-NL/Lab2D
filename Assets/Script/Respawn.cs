using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector2 startPos;
    SpriteRenderer spriteRenderer;
    Animator animator;

    public PlayerStat PS;

    public GameObject respawnPoint;
    [SerializeField] private float hitAnimationDuration = 0.5f;
    [SerializeField] private float invincibilityDuration = 1f;
    
    private bool isInvincible = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInvincible)
        {
            StartCoroutine(HandleEnemyCollision());
        }
        if (collision.CompareTag("InstantDeath"))
        {
            PS.GoneHP();
        }
    }

    IEnumerator HandleEnemyCollision()
    {
        isInvincible = true;
        DieToRespawnPoint();
        PS.ReduceHP();

        StartCoroutine(FlashSprite());
        
        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
    }

    void DieToRespawnPoint()
    {
        StartCoroutine(RespawnAtGameObject(0.1f));
    }

    IEnumerator RespawnAtGameObject(float duration)
    {
        PlayHitAnimation();
        yield return new WaitForSeconds(duration);
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.transform.position;
        }
        StopHitAnimationAfterDelay();
    }

    void PlayHitAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("GotHit");
        }
    }

    void StopHitAnimationAfterDelay()
    {
        StartCoroutine(ResetHitAnimation());
    }

    IEnumerator ResetHitAnimation()
    {
        yield return new WaitForSeconds(hitAnimationDuration);
        if (animator != null)
        {
            animator.ResetTrigger("GotHit");
        }
    }

    IEnumerator FlashSprite()
    {
        if (spriteRenderer != null)
        {
            for (float i = 0; i < invincibilityDuration; i += 0.2f)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(0.1f);
            }
            spriteRenderer.enabled = true;
        }
    }
}
