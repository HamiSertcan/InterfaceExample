using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<EnemyAnim>().enabled = true;
            Game_Manager.ZombieAttack.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Game_Manager.ZombieAttackEnd.Invoke();
        }
    }
}
