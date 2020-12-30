using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public static float aim_radius;
    public static float aim_radius_factor;
    float mesafe;
    public static GameObject target;
    public GameObject kamera;
    public GameObject shoot_point;
    public GameObject blood;
    public GameObject shootParticle;
    ParticleSystem shootParticleSystem;
    ParticleSystem bloodParticle;
    public GameObject dust;
    ParticleSystem dustParticle;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        bloodParticle = blood.GetComponent<ParticleSystem>();
        dustParticle = dust.gameObject.GetComponent<ParticleSystem>();
        shootParticleSystem = shootParticle.transform.GetChild(0).GetComponent<ParticleSystem>();
    aim_radius_factor = 0.2f; // 5 metrede dağılma 1 olacak şekilde ayarladım
    }
    private void OnEnable()
    {
        Game_Manager.Shoot.AddListener(Shoot);
    }
    private void OnDisable()
    {
        Game_Manager.Shoot.RemoveListener(Shoot);
    }

    RaycastHit nesne;
    RaycastHit target_nesne;

    void Shoot()
    {
        // Öncelikle dağılma için sahnenin ortaasından bir ışın yolluyorum.
        // Bu ışının çarptığı obje ile aradaki mesafeyi ölçüyorum. Ölçülen mesafeye göre ve Cursor_Scale kodu içerisinde 
        // hareket durumlarına göre belirlenen dağılma oranına göre hedef noktasını konumlandırıyorum.
        Ray isik_yolla = kamera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(isik_yolla, out nesne, 80f))
        {
            aim_radius_factor = Cursor_Scale.cap;
            // ışının çarptığı nokta ile kamera arasındaki mesafeyi ölçüyorum
            mesafe = Vector3.Distance(kamera.transform.position, nesne.point);
            // dağılma için çap hesaplıyorum
            aim_radius = mesafe * aim_radius_factor;
            // hedef noktasını dağılma çapına göre rastgele bir noktaya konumlandırıyorum
            //target.transform.position = nesne.point;
            target.transform.position = nesne.point + new Vector3(Random.Range(-aim_radius / 2, aim_radius / 2), Random.Range(-aim_radius / 2, aim_radius / 2), Random.Range(-aim_radius / 2, aim_radius / 2));
        }
        // ışın hiçbir yere çarpmıyorsa kameradan 50 birim uzaklığa konumlandırıyorum
        else
        {
            target.transform.rotation = kamera.transform.rotation;
            target.transform.position = kamera.transform.position;
            target.transform.Translate(0, 0, 50);
        }

        shoot_point.transform.LookAt(target.transform.position);
        
        // Sahnenin orta noktasından konumlandırılmış hedef noktasa bir ışın yolluyorum.
        // Işının çarptığı objeyi kontrol ediyorum ve yapılacak işlemleri tetikliyorum.
        if (Physics.Raycast(shoot_point.transform.position, shoot_point.transform.forward, out target_nesne, 100f))
        {
            
            GameObject HitObje = target_nesne.collider.gameObject;
            // İşlemler parentHitObje ye göre yapılıyor. Eğer objenin parenti varsa örneğin düşmanın koluna ateş edilmiş ise bu objenin bağlı olduğu ana obje ParentHitObje yapılıyor.
            // Eğer hedef noktasının çarptığı objenin parenti yoksa ParentHitObje olarak hedef noktasının çarptığı objeyi ParentHitObje yapıyorum.
            // HitObje kaydı tutmamın sebebi hedefin farklı noktlarına yapılan atışlarda farklı hasar atabilme ve farklı animasyonlar oynatabilme imkanı sunması
            if (HitObje.transform.root != null)
            {
                Game_Manager.ParentHitObje = HitObje.transform.root.gameObject;
                Game_Manager.HitObje = HitObje;
                if (Game_Manager.ParentHitObje.CompareTag("Enemy"))
                {
                    blood.transform.position = target_nesne.point;
                    bloodParticle.Play();
                }
                else
                {
                    dust.transform.position = target_nesne.point;
                    dustParticle.Play();
                }
            }
            else
            {
                Game_Manager.ParentHitObje = HitObje;
            }
            IHit();
            shootParticle.transform.LookAt(target_nesne.point);
            shootParticleSystem.Play();
        }
        else
        {
            shootParticle.transform.LookAt(target.transform.position);
            shootParticleSystem.Play();
        }
        
    }

    void IHit()
    {
        IHit hit = Game_Manager.ParentHitObje.GetComponent<IHit>();
        if (hit != null)
        {
            Game_Manager.Interaction.RemoveAllListeners();
            hit.Hit();
        }
    }
}
