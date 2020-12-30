using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator animator;
    bool kapi_acik;
    private void Start()
    {
        kapi_acik = false;
        animator = gameObject.GetComponent<Animator>();
    }
    public void Interact()
    {
        
        
        // interaction text için GameManger içindeki string güncelleniyor.
        if (kapi_acik == true)
        {
            Game_Manager.Interaction.AddListener(KapiyiKapat);
            Game_Manager.interactionText = "Press [E] to close the door";
        }
        else
        {
            Game_Manager.Interaction.AddListener(KapiyiAc);
            Game_Manager.interactionText = "Press [E] to open the door";
        }
        
        Game_Manager.OpenInteractionText.Invoke();
    }

    void OnDisable()
    {
        Game_Manager.Interaction.RemoveListener(KapiyiAc);
        Game_Manager.Interaction.RemoveListener(KapiyiKapat);
    }

    void KapiyiAc()
    {
        kapi_acik = true;
        animator.SetBool("openDoor", true);
        Game_Manager.CloseInteractionText.Invoke();
        StartCoroutine(openDoorFalse());
    }
    IEnumerator openDoorFalse()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("openDoor", false);
    }

    void KapiyiKapat()
    {
        kapi_acik = false;
        animator.SetBool("closeDoor", true);
        Game_Manager.CloseInteractionText.Invoke();
        StartCoroutine(closeDoorFalse());
    }

    IEnumerator closeDoorFalse()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("closeDoor", false);
    }
}
