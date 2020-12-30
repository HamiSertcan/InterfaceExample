using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletText : MonoBehaviour
{
    private void Start()
    {
        MermiYazisiniGuncelle();
    }
    private void OnEnable()
    {
        gameObject.GetComponent<Text>().text = Game_Manager.mermiSayisi.ToString();
        Game_Manager.BulletCollect.AddListener(MermiYazisiniGuncelle);
        Game_Manager.ReloadMagazine.AddListener(MermiYazisiniGuncelle);
        Game_Manager.RefreshBulletText.AddListener(MermiYazisiniGuncelle);
    }
    private void OnDisable()
    {
        Game_Manager.BulletCollect.RemoveListener(MermiYazisiniGuncelle);
        Game_Manager.ReloadMagazine.RemoveListener(MermiYazisiniGuncelle);
        Game_Manager.RefreshBulletText.RemoveListener(MermiYazisiniGuncelle);
    }

    void MermiYazisiniGuncelle()
    {
        string sarjordekiMermi = Game_Manager.sarjordekiMermiSayisi.ToString();
        string mermiSayisi = Game_Manager.mermiSayisi.ToString();
        gameObject.GetComponent<Text>().text = sarjordekiMermi+"/"+mermiSayisi;
    }
}
