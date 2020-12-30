using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Scale : MonoBehaviour
{
    public static float cap;
    // Start is called before the first frame update
    void Start()
    {
        cap_hesapla();
        transform.localScale = new Vector3(cap, cap, cap);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && Karakter_Kontrol.walk == false)
        {
            if (0.02f < cap)
            {
                cap -= Time.deltaTime / 8f;
            }
        }
        //if (Input.GetMouseButtonUp(1) || Karakter_Kontrol.walk == true)
        else
        {
            cap_hesapla();
        }
        transform.localScale = new Vector3(cap, cap, cap);
    }

    void cap_hesapla()
    {
        if (Karakter_Kontrol.run == true)
        {
            cap = 0.09f;
        }
        else if (Karakter_Kontrol.walk == true)
        {
            cap = 0.065f;
        }
        else
        {
            cap = 0.04f;
        }
    }
}
