using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void OnEnable()
    {
        Game_Manager.Shoot.AddListener(Fire);
    }
    private void OnDisable()
    {
        Game_Manager.Shoot.RemoveListener(Fire);
    }

    void Fire()
    {
        Game_Manager.sarjordekiMermiSayisi--;
        Game_Manager.RefreshBulletText.Invoke();
    }
}
