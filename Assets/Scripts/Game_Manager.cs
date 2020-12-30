using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{
    // Karakter ateş ettiğinde oynatılan animasyonun içerisindeki event Shoot eventını tetikliyor.
    // Ateş sesinin oynatılması, parçacık sisteminin çalıştırılması, hedef noktasının konumlandırılması, mermi sayısının azaltılması 
    public static UnityEvent Shoot = new UnityEvent();
    // Hit eventı Shoot eventından sonra Target kodu içerisinde çalışıyor.
    // hedef seçildikten sonra tetikleniyor. Hedefe göre; hasar atılması, farklı seslerin çalınması, farklı mermi izleri vs bu event ile çalışıyor.
    public static UnityEvent Hit = new UnityEvent();
    public static UnityEvent HeadShot = new UnityEvent();
    public static UnityEvent NoAmmo = new UnityEvent();
    public static UnityEvent RefreshBulletText = new UnityEvent();

    public static UnityEvent HareketliShoot = new UnityEvent();
    public static UnityEvent Walk = new UnityEvent();
    public static UnityEvent WalkRight = new UnityEvent();
    public static UnityEvent WalkLeft = new UnityEvent();
    public static UnityEvent WalkBackward = new UnityEvent();
    public static UnityEvent Run = new UnityEvent();
    public static UnityEvent RunBackward = new UnityEvent();
    public static UnityEvent Idle = new UnityEvent();

    public static UnityEvent ZombieAttack = new UnityEvent();
    public static UnityEvent ZombiePunch = new UnityEvent();
    public static UnityEvent ZombieAttackEnd = new UnityEvent();
    public static UnityEvent EnemyHit = new UnityEvent();
    public static UnityEvent EnemyKill = new UnityEvent();
    public static UnityEvent RefreshHealthBar = new UnityEvent();
    // yürüme koşma gibi animasyonlarda adım yere değdiğinde çağrılıyor. 
    public static UnityEvent FootStep = new UnityEvent();

    // Etkileşimler
    public static string interactionText;
    public static UnityEvent OpenInteractionText = new UnityEvent();
    public static UnityEvent CloseInteractionText = new UnityEvent();
    public static UnityEvent Interaction = new UnityEvent();
    public static UnityEvent AppleCollect = new UnityEvent();
    public static UnityEvent BulletCollect = new UnityEvent();
    // Elma yeme, mermi doldurma vs.
    public static UnityEvent EatApple = new UnityEvent();
    public static UnityEvent ReloadMagazine = new UnityEvent();
    public static UnityEvent ReloadControl = new UnityEvent();

    public static UnityEvent GameOver = new UnityEvent();

    public static GameObject HitObje;
    public static GameObject ParentHitObje;

    public static float canPuani;
    public static int canYenilemePuani;
    public static int zombiHasari;
    public static int enemyHealth;
    public static int shotDamage;
    public static int headShotDamage;
    public static int elmaSayisi;
    public static int mermiSayisi;
    public static int sarjordekiMermiSayisi;
    public static int sarjorKapasitesi;

    public static float gameTime;

    // mermi veya elma toplandığında oyantılan parçacık sistemi
    // Karakter etkileşimli objelere temas ettiğinde temas edilen objelerin kodları içerisinde konumu çarpılan objeye eşitleniyor.
    public static GameObject collectParticle;

    void Awake()
    {
        collectParticle = GameObject.FindGameObjectWithTag("CollectParticle");
        HitObje = new GameObject();
        // Değişkenlerin başlangıç değerleri
        canPuani = 100;
        canYenilemePuani = 25;
        zombiHasari = 20;
        enemyHealth = 100;
        shotDamage = 50;
        headShotDamage = 100;

        elmaSayisi = 0;

        sarjorKapasitesi = 6;
        sarjordekiMermiSayisi = 6;
        mermiSayisi = 6;

        //Cursor.visible = false;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

}
