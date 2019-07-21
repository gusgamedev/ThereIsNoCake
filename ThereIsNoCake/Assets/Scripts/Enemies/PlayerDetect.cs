using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [HideInInspector] public float hitRadius = 2f;
    public LayerMask enemyLayer;
    public Vector2 offset = Vector2.zero;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy._isAlive)
        {
            HitCheck();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + offset, hitRadius);
    }

    private void HitCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2)transform.position + offset, hitRadius, enemyLayer);

        if (hits != null)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    hit.GetComponent<Player>().TakeDamage(1);
                }
            }
        }
    }
}
