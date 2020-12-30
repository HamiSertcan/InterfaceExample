using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterCani : MonoBehaviour
{
    int canYenilemePuani;
    int zombiHasari;
    private void OnEnable()
    {
        canYenilemePuani = Game_Manager.canYenilemePuani;
        zombiHasari = Game_Manager.zombiHasari;
        Game_Manager.EatApple.AddListener(CanYenile);
        Game_Manager.ZombiePunch.AddListener(ZombiHasari);
    }
    private void OnDisable()
    {
        Game_Manager.EatApple.RemoveListener(CanYenile);
        Game_Manager.ZombiePunch.RemoveListener(ZombiHasari);
    }

    void CanYenile()
    {
        float canPuani = Game_Manager.canPuani;
        if (canPuani < 100)
        {
            canPuani += canYenilemePuani;
        }
        if (canPuani > 100)
        {
            canPuani = 100;
        }
        Game_Manager.canPuani = canPuani;
        Game_Manager.RefreshHealthBar.Invoke();
    }
    void ZombiHasari()
    {
        float canPuani = Game_Manager.canPuani;
        if (canPuani > 0)
        {
            canPuani -= zombiHasari;
            Game_Manager.canPuani = canPuani;
            Game_Manager.RefreshHealthBar.Invoke();
        }
        if (canPuani <= 0)
        {
            Game_Manager.GameOver.Invoke();
        }
        
    }
}
