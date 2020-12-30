using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour
{
    private void OnEnable()
    {
        Game_Manager.HeadShot.AddListener(Headshot);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        Game_Manager.HeadShot.RemoveListener(Headshot);
    }

    void Headshot()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(kapat());
    }

    IEnumerator kapat()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
