using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieLimit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("aqui");
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(player.health);
        }
        else
        {
            Destroy(other.gameObject);
        }

    }
}
