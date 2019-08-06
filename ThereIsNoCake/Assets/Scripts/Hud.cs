using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject[] hearts;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        hearts[0].SetActive(player.health > 0);
        hearts[1].SetActive(player.health > 1);
        hearts[2].SetActive(player.health > 2);
        
    }
}
