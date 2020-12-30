using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IHit
{
    int health;
    int shotDamage;
    int headShotDamage;

    void Start()
    {
        health = Game_Manager.enemyHealth;
        shotDamage = Game_Manager.shotDamage;
        headShotDamage = Game_Manager.headShotDamage;
    }
    public void Hit()
    {
        if (gameObject.GetComponent<EnemyAnim>() != null)
        {
            gameObject.GetComponent<EnemyAnim>().enabled = true;
        }
        Game_Manager.Hit.Invoke();
        // Vuruş yapılan yere göre health azaltma
        if (Game_Manager.HitObje.CompareTag("EnemyHead"))
        {
            health -= headShotDamage;
            Game_Manager.HeadShot.Invoke();
        }
        else
        {
            health -= shotDamage;
        }

        // atılan hasardan sonraki durum için can puanı kontrolü ve ilgili eventların tetiklenmesi
        if (health <= 0)
        {
            // düşmanın ölüm animasyonunun oynatılabilmesi için
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject.GetComponent<EnemyAttack>());
            gameObject.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<AI>().canlilik = false;
            if (gameObject.GetComponent<EnemyAnim>() != null)
            {
                gameObject.GetComponent<EnemyAnim>().enabled = true;
                Game_Manager.EnemyKill.Invoke();
            }
        }
        if (health > 0)
        {
            // düşmana hasar aldığına dair animasyon oynatılabilmesi için
            if (gameObject.GetComponent<EnemyAnim>() != null)
            {
                gameObject.GetComponent<EnemyAnim>().enabled = true;
                Game_Manager.EnemyHit.Invoke();
            }
        } 
    }
}
