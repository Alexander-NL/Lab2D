using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject Capsule;
    public PlayerStat PS;
    public ParticleSystem particle;

    void Start(){
        Capsule = GameObject.Find("Capsule");
        PS = Capsule.GetComponent<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            PS.KillEnemy();
            particle.Play();

            Destroy(other.gameObject);
        }
    }
}
