using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{
    bool one_time;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        one_time = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && one_time==false)
        {
            one_time = true;
            Game_Manager.Interaction.Invoke();
        }
    }
}
