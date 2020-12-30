using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        this.enabled = false;
    }

    private void OnEnable()
    {
        Game_Manager.ZombieAttack.AddListener(Attack);
        Game_Manager.ZombieAttackEnd.AddListener(EndAttack);
        Game_Manager.EnemyHit.AddListener(BulletHit);
        Game_Manager.EnemyKill.AddListener(Dead);
    }
    private void OnDisable()
    {
        Game_Manager.ZombieAttack.RemoveListener(Attack);
        Game_Manager.ZombieAttackEnd.RemoveListener(EndAttack);
        Game_Manager.EnemyHit.RemoveListener(BulletHit);
        Game_Manager.EnemyKill.RemoveListener(Dead);
    }
    void Attack()
    {
        animator.SetBool("attack", true);
    }
    void EndAttack()
    {
        animator.SetBool("attack", false);
        this.enabled = false;
    }

    public void ZombiePunchSound()
    {
        Game_Manager.ZombiePunch.Invoke();
    }

    void BulletHit()
    {
        animator.SetBool("bulletHit", true);
        StartCoroutine(BulletHitFalse());
        StartCoroutine(KoduKapat());
    }

    void Dead()
    {
        animator.SetBool("dead", true);
        animator.SetBool("idle", false);
        gameObject.GetComponent<AI>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        StartCoroutine(DeadFalse());
        StartCoroutine(ObjeyiSil());
    }

    

    IEnumerator BulletHitFalse()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("bulletHit", false);
    }
    IEnumerator DeadFalse()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("dead", false);
    }
    IEnumerator KoduKapat()
    {
        yield return new WaitForSeconds(1);
        this.enabled = false;
    }
    IEnumerator ObjeyiSil()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

}
