using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour,IInteractable
{
    public bool particle_effect;
    public void Interact()
    {
        Game_Manager.Interaction.AddListener(ElmaTopla);
        // interaction text için GameManger içindeki string güncelleniyor.
        Game_Manager.interactionText = "Press [E] to pick up";
        Game_Manager.OpenInteractionText.Invoke();
    }

    void OnDisable()
    {
        Game_Manager.Interaction.RemoveListener(ElmaTopla);
    }

    void ElmaTopla()
    {
        Game_Manager.elmaSayisi += 1;
        if (particle_effect == true)
        {
            GameObject particle_effect = Game_Manager.collectParticle;
            particle_effect.transform.position = gameObject.transform.position;
            particle_effect.GetComponent<ParticleSystem>().Play();
        }
        Game_Manager.AppleCollect.Invoke();
        ElmayiKapat();
        StartCoroutine(ElmaEkle());
    }

    // Oyun sürekliliğinin sağlanabilmesi için toplanan objeleri belirli bir süre sonra yeniden toplanabilir hale getiriyorum.
    IEnumerator ElmaEkle()
    {
        yield return new WaitForSeconds(40);
        ElmayiAc();
    }

    void ElmayiKapat()
    {
        Game_Manager.CloseInteractionText.Invoke();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void ElmayiAc()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

}
