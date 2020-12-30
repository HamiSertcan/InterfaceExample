using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    GameObject background,interaction_text;
    private void OnEnable()
    {
        background = transform.GetChild(0).gameObject;
        interaction_text = background.transform.GetChild(0).gameObject;
        Game_Manager.OpenInteractionText.AddListener(YaziyiGoster);
        Game_Manager.CloseInteractionText.AddListener(YaziyiKapat);
    }
    private void OnDisable()
    {
        Game_Manager.OpenInteractionText.RemoveListener(YaziyiGoster);
        Game_Manager.CloseInteractionText.RemoveListener(YaziyiKapat);
    }

    void YaziyiGoster()
    {
        background.SetActive(true);
        // gösterilecek yazıyı güncelliyorum
        interaction_text.GetComponent<Text>().text = Game_Manager.interactionText; 
    }

    void YaziyiKapat()
    {
        background.SetActive(false);
    }
}
