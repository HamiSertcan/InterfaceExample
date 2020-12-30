using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = "0";
    }

    private void OnEnable()
    {
        Game_Manager.EnemyKill.AddListener(UpdateScore);
    }
    private void OnDisable()
    {
        Game_Manager.EnemyKill.RemoveListener(UpdateScore);
    }


    void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
