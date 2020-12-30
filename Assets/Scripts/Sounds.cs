using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sounds : MonoBehaviour
{
    public List<AudioClip> sesEfektleri;
    public AudioSource ses;
    public static float volume;

    // Start is called before the first frame update
    void OnEnable()
    {
        Game_Manager.Shoot.AddListener(ShootSoundFX);
        Game_Manager.FootStep.AddListener(FootStepSoundFX);
        Game_Manager.AppleCollect.AddListener(CollectSoundFX);
        Game_Manager.BulletCollect.AddListener(CollectSoundFX);
        Game_Manager.EatApple.AddListener(EatAppleSoundFX);
        Game_Manager.NoAmmo.AddListener(GunTriggerSoundFX);
        Game_Manager.ReloadMagazine.AddListener(ReloadMagazineSoundFX);
        Game_Manager.ZombiePunch.AddListener(ZombieAttackSoundFX);
        volume = 1f;
    }
    private void OnDisable()
    {
        Game_Manager.Shoot.RemoveListener(ShootSoundFX);
        Game_Manager.FootStep.RemoveListener(FootStepSoundFX);
        Game_Manager.AppleCollect.RemoveListener(CollectSoundFX);
        Game_Manager.BulletCollect.RemoveListener(CollectSoundFX);
        Game_Manager.EatApple.RemoveListener(EatAppleSoundFX);
        Game_Manager.NoAmmo.RemoveListener(GunTriggerSoundFX);
        Game_Manager.ReloadMagazine.RemoveListener(ReloadMagazineSoundFX);
        Game_Manager.ZombiePunch.RemoveListener(ZombieAttackSoundFX);
    }

    void ShootSoundFX()
    {
        ses.pitch=Random.Range(0.8f, 1.5f);
        ses.PlayOneShot(sesEfektleri[0], volume);
    }

    void FootStepSoundFX()
    {
        ses.pitch = Random.Range(1f, 1.5f);
        ses.PlayOneShot(sesEfektleri[Random.Range(1, 3)], volume);
    }

    void CollectSoundFX()
    {
        ses.PlayOneShot(sesEfektleri[3], volume);
    }

    void EatAppleSoundFX()
    {
        ses.PlayOneShot(sesEfektleri[4], volume);
    }

    void GunTriggerSoundFX()
    {
        ses.PlayOneShot(sesEfektleri[5], volume);
    }

    void ReloadMagazineSoundFX()
    {
        ses.PlayOneShot(sesEfektleri[6], volume);
        
    }

    void ZombieAttackSoundFX()
    {
        ses.pitch = Random.Range(1f, 1.5f);
        ses.PlayOneShot(sesEfektleri[7], volume);

    }

}
