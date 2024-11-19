using UnityEngine;

public class DespawnOnDistance : MonoBehaviour
{
    public Transform player;
    public float despawnDistance = 15f;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
