using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Particle : MonoBehaviour
{
    ParticleSystem particleShoot;
    private void OnEnable()
    {
        particleShoot= gameObject.GetComponent<ParticleSystem>();
        Game_Manager.Shoot.AddListener(playParticle);
    }

    private void OnDisable()
    {
        Game_Manager.Shoot.RemoveListener(playParticle);
    }

    void playParticle()
    {
        particleShoot.Play();
    }
}
