using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleText : MonoBehaviour
{
    
    private void OnEnable()
    {
        gameObject.GetComponent<Text>().text = Game_Manager.elmaSayisi.ToString();
        Game_Manager.AppleCollect.AddListener(ElmaYazisiniGuncelle);
        Game_Manager.EatApple.AddListener(ElmaYazisiniGuncelle);
    }
    private void OnDisable()
    {
        Game_Manager.AppleCollect.RemoveListener(ElmaYazisiniGuncelle);
        Game_Manager.EatApple.RemoveListener(ElmaYazisiniGuncelle);
    }

    void ElmaYazisiniGuncelle()
    {
        gameObject.GetComponent<Text>().text = Game_Manager.elmaSayisi.ToString();
    }
}
