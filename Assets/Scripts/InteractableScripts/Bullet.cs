﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IInteractable
{
    public bool particle_effect;
    public void Interact()
    {
        Game_Manager.Interaction.AddListener(MermiTopla);
        // interaction text için GameManger içindeki string güncelleniyor.
        Game_Manager.interactionText = "Press [E] to pick up";
        Game_Manager.OpenInteractionText.Invoke();
    }

    void OnDisable()
    {
        Game_Manager.Interaction.RemoveListener(MermiTopla);
    }

    void MermiTopla()
    {
        Game_Manager.mermiSayisi += Game_Manager.sarjorKapasitesi;
        if (particle_effect == true)
        {
            GameObject particle_effect = Game_Manager.collectParticle;
            particle_effect.transform.position = gameObject.transform.position;
            particle_effect.GetComponent<ParticleSystem>().Play();
        }
        Game_Manager.BulletCollect.Invoke();
        MermiyiKapat();
        StartCoroutine(MermiEkle());
    }

    // Oyun sürekliliğinin sağlanabilmesi için toplanan objeleri belirli bir süre sonra yeniden toplanabilir hale getiriyorum.
    IEnumerator MermiEkle()
    {
        yield return new WaitForSeconds(40);
        MermiyiAc();
    }

    void MermiyiKapat()
    {
        Game_Manager.CloseInteractionText.Invoke();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void MermiyiAc()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}