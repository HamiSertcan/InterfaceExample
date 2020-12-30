using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    public float dusman_ekleme_suresi;
    float ekleme_suresi;
    float timer;
    public GameObject enemy;

    private void Start()
    {
        timer = Random.Range(dusman_ekleme_suresi * 3 / 4, dusman_ekleme_suresi);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ekleme_suresi)
        {
            timer = 0;
            float eklemeSuresi = dusman_ekleme_suresi - Game_Manager.gameTime/30;
            ekleme_suresi = Random.Range(eklemeSuresi- eklemeSuresi/2, eklemeSuresi+ eklemeSuresi/2);
            GameObject Enemy = Instantiate(enemy,transform.position, gameObject.transform.rotation);
        }
        
    }
}
