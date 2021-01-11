using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    public Text scoreText;
    public GameStateSO gameState;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = gameState.Points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
