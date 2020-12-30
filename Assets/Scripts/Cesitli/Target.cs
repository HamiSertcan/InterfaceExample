using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 harita_disi = new Vector3(0, -30, 0);
    private void OnTriggerEnter(Collider other)
    {
        GameObject HitObje = other.gameObject;

        
        print(other.gameObject.transform.root);
        // İşlemler parentHitObje ye göre yapılıyor. Eğer objenin parenti varsa örneğin düşmanın koluna ateş edilmiş ise bu objenin bağlı olduğu ana obje ParentHitObje yapılıyor.
        // Eğer hedef noktasının çarptığı objenin parenti yoksa ParentHitObje olarak hedef noktasının çarptığı objeyi ParentHitObje yapıyorum.
        // HitObje kaydı tutmamın sebebi hedefin farklı noktlarına yapılan atışlarda farklı hasar atabilme ve farklı animasyonlar oynatabilme imkanı sunması
        if (HitObje.transform.root != null)
        {
            Game_Manager.ParentHitObje = other.gameObject.transform.root.gameObject;
            Game_Manager.HitObje = other.gameObject;
        }
        else
        {
            Game_Manager.ParentHitObje = other.gameObject;
        }
        // Düşman hareket ederken düşmanın başka collision larıda hasar tetiklemesin diye konum değiştiriyorum :)
        gameObject.transform.position = harita_disi;
        Game_Manager.Hit.Invoke();
    }


}
