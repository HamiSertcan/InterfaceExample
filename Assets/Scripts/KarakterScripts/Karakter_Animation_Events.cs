using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter_Animation_Events : MonoBehaviour
{
    static Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Game_Manager.ZombiePunch.AddListener(HitReaction);
    }
    private void OnDisable()
    {
        Game_Manager.ZombiePunch.RemoveListener(HitReaction);

    }

    public void fire()
    {
        Game_Manager.Shoot.Invoke();
    }
    public void fire_end()
    {
        animator.SetBool("shoot", false);
        animator.SetBool("hareketli_shoot", false);
    }
    void FootStepEvent()
    {
        Game_Manager.FootStep.Invoke();
    }

    void HitReaction()
    {
        animator.SetBool("hit", true);
        StartCoroutine(hitFalse());
    }
    IEnumerator hitFalse()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("hit", false);
    }
}

