using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour
{
    public static float doldurmaZamani;
    float timer;
    Image bulletBar;

    private void Start()
    {
        bulletBar = gameObject.GetComponent<Image>();
        doldurmaZamani = 0;
        timer = 0;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < doldurmaZamani)
        {
            bulletBar.fillAmount = timer * 1 / doldurmaZamani;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
