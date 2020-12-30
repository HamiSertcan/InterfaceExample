using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiDoldurma : MonoBehaviour
{
    public GameObject bulletBar;
    float doldurmaZamani = 3f;
    private void OnEnable()
    {
        Game_Manager.ReloadMagazine.AddListener(mermiDoldur);
    }
    private void OnDisable()
    {
        Game_Manager.ReloadMagazine.RemoveListener(mermiDoldur);
    }

    void mermiDoldur()
    {
        Game_Manager.ReloadControl.Invoke();
        if (bulletBar != null)
        {
            bulletBar.SetActive(true);
            BulletBar.doldurmaZamani = doldurmaZamani;
        }
        StartCoroutine(Reload());
    }

    // şarjördeki mermi bittiğinde Karakter_Kontrol yazılımı içindeki doldurma değişkeni false oluyor ve bu sebeple ateş edilemiyor.
    // Mermi doldurulduktan sonra ateş edilebilmesi için bu değişken true yapılıyor. (BulletControl eventi sayesinde)
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(doldurmaZamani);
        int sarjorkapasitesi = Game_Manager.sarjorKapasitesi;
        int sarjordekiMermiSayisi = Game_Manager.sarjordekiMermiSayisi;
        int toplamMermiSayisi = Game_Manager.mermiSayisi + sarjordekiMermiSayisi;
        
        // mermi sayısı şarjör kapasitesinden az ise
        if (toplamMermiSayisi < sarjorkapasitesi)
        {
            sarjordekiMermiSayisi = toplamMermiSayisi;
            Game_Manager.sarjordekiMermiSayisi = sarjordekiMermiSayisi;
        }
        // mermi sayısı şarjör kapasitesinden fazla ise
        if (toplamMermiSayisi >= sarjorkapasitesi)
        {
            sarjordekiMermiSayisi = sarjorkapasitesi;
            Game_Manager.sarjordekiMermiSayisi = sarjordekiMermiSayisi;
        }
        Game_Manager.mermiSayisi = toplamMermiSayisi - sarjordekiMermiSayisi;
        Game_Manager.RefreshBulletText.Invoke();
        Game_Manager.ReloadControl.Invoke();
    }
}
