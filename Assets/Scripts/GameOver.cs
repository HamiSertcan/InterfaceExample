using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Game_Manager.GameOver.AddListener(Game_Over);
        gameObject.transform.GetChild(0).gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void OnDisable()
    {
        Game_Manager.GameOver.RemoveListener(Game_Over);
    }
    void Game_Over()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    public void Replay()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
