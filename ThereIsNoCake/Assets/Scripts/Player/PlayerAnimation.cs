using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Player player;
    FlashDamage damageEffect;
    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>();
        damageEffect = GetComponent<FlashDamage>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRun(float move)
    {
        animator.SetFloat("run", Mathf.Abs(move));
    }

    public void PlayerJump(bool isOnFloor)
    {
        animator.SetBool("jump", !isOnFloor);
       

    }

    public void PlayerAttack()
    {
        animator.SetTrigger("attack");        
    }

    public void StopAttack()
    {
        player.StopAttack();
    }

    public void EnableHit()
    {
        player.EnableAttackHit();
        Instantiate(cameraShake, transform.position, transform.rotation);
    }

    public void PlayerDamage()
    {
        damageEffect.SetFlashDamage();
    }

    public void PlayerDie()
    {
        animator.SetTrigger("die");
    }



}
