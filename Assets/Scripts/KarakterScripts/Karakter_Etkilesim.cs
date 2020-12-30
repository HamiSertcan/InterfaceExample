using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter_Etkilesim : MonoBehaviour
{
    bool etkilesimli_obje;
    private void OnTriggerEnter(Collider collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            etkilesimli_obje = true;
            Game_Manager.Interaction.RemoveAllListeners();
            interactable.Interact();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (etkilesimli_obje == true)
        {
            etkilesimli_obje = false;
            Game_Manager.CloseInteractionText.Invoke();
        }
    }

}
