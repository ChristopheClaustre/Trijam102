using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int timer = 30;
    public Text timerText;
    public Text pointsText;
    public GameStateSO gameState;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManageTimer());
        StartCoroutine(ManagePoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ManageTimer()
    {
        while (timer > 0)
        {
            timerText.text = timer.ToString();

            yield return new WaitForSeconds(1);
            timer--;
        }

        timerText.text = timer.ToString();
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(2);
    }

    IEnumerator ManagePoints()
    {
        pointsText.text = gameState.Points.ToString();

        while (true)
        {
            int lastPoints = gameState.Points;
            yield return new WaitUntil(() => lastPoints != gameState.Points);

            pointsText.text = gameState.Points.ToString();
        }
    }
}
