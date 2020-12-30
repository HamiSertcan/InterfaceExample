using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter_Kontrol : MonoBehaviour
{
    public float speed;
    public static bool run;
    public static bool walk;
    //Mermi yüklenirken tetik sesi çalmasın diye var
    bool doldurma;
    int doldurma_int = 0;

    public float rotation_speed = 2.0f;
    private float yaw = 0.0f;

    Animator animator;
    void Start()
    {
        doldurma = false;
        run = false;
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Game_Manager.ReloadControl.AddListener(MermiYuklemeDurumu);
    }
    private void OnDisable()
    {
        Game_Manager.ReloadControl.RemoveListener(MermiYuklemeDurumu);
    }

    void MermiYuklemeDurumu()
    {
        doldurma_int++;
        if (doldurma_int % 2 == 0)
        {
            doldurma = false;
        }
        else
        {
            doldurma = true;
        }

    }

    void Update()
    {
        // KARAKTER Y ROTASYONU
        yaw += rotation_speed * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0f, yaw, 0.0f);

        // ATEŞ ETME
        if (Input.GetMouseButtonDown(0) && doldurma == false)
        {
            if (Game_Manager.sarjordekiMermiSayisi > 0)
            {
                // Shoot eventı animasyon ile tetikleniyor. Karakter Animation Event içerisinde
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    animator.SetBool("hareketli_shoot", true);
                }
                else
                {
                    animator.SetBool("shoot", true);
                }
            }
            if (Game_Manager.sarjordekiMermiSayisi <= 0)
            {
                Game_Manager.NoAmmo.Invoke();
            }
        }

        //NISAN ALMA
        if (Input.GetMouseButtonDown(1) && walk==false)
        {
            animator.SetBool("idle", false);
            animator.SetBool("aim", true);
        }
        if (Input.GetMouseButtonUp(1) || walk==true)
        {
            animator.SetBool("aim", false);
            animator.SetBool("idle", true);
        }

        // MERMI YUKLEME
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Game_Manager.mermiSayisi > 0)
            {
                Game_Manager.ReloadMagazine.Invoke();
            }
        }

        // ELMA YEME
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Game_Manager.elmaSayisi > 0)
            {
                Game_Manager.elmaSayisi -= 1;
                Game_Manager.EatApple.Invoke();
                

            }
        }

        //KOŞMA AKTİVİTESİ
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = true;
            animator.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            run = false;
            animator.SetBool("run", false);
        }


        // İLERİ
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);
            if (run == false)
            {
                gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
                walk = true;
            }
            else
            {
                gameObject.transform.Translate(0, 0, speed * 2 * Time.deltaTime);
            }
        }
        // GERİ
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("walk_backward", true);
            animator.SetBool("idle", false);
            if (run == false)
            {
                gameObject.transform.Translate(0, 0, -speed * Time.deltaTime);
                walk = true;
            }
            else
            {
                gameObject.transform.Translate(0, 0, -speed * 2 * Time.deltaTime);
            }
        }
        // SAG
        if (Input.GetKey(KeyCode.D))
        {
            if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                animator.SetBool("walk_right", true);
                animator.SetBool("idle", false);
                if (run == false)
                {
                    gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
                    walk = true;
                }
                else
                {
                    gameObject.transform.Translate(speed * 2 * Time.deltaTime, 0, 0);
                }
            }
        }
        // SOL
        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                animator.SetBool("walk_left", true);
                animator.SetBool("idle", false);
                if (run == false)
                {
                    gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
                    walk = true;
                }
                else
                {
                    gameObject.transform.Translate(-speed * 2 * Time.deltaTime, 0, 0);
                }
            }
        }

        // ANİMASYON PARAMETRELERİNİ KAPATMA
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("walk_backward", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("walk_right", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("walk_left", false);
        }

        // IDLE A GEÇİŞ
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A))
            {
                animator.SetBool("idle",true);
                walk = false;
            }
        }
    }
}
