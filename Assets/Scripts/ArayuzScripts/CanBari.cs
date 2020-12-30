using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanBari : MonoBehaviour
{
    Image canBari;
    private void Start()
    {
        canBari = gameObject.GetComponent<Image>();
    }
    private void OnEnable()
    {
        Game_Manager.RefreshHealthBar.AddListener(CanBariniGuncelle);
    }
    private void OnDisable()
    {
        Game_Manager.RefreshHealthBar.RemoveListener(CanBariniGuncelle);
    }

    void CanBariniGuncelle()
    {
        canBari.fillAmount = Game_Manager.canPuani / 100;
    }
}
