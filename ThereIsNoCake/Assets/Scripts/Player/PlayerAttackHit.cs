using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHit : MonoBehaviour
{

    public float hitRadius = 2f;
    public bool hitEnabled = false;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitEnabled)
        {
            HitCheck();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, hitRadius);
    }

    private void HitCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2)transform.position, hitRadius, enemyLayer);

        if (hits != null)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().TakeDamage(1);
                    
                    

                }
            }
        }
    }
}
