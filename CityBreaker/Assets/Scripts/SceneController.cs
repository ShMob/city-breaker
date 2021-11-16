using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject ballPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loseScoreText;
    public GameObject losePanel;
    private int score;
    private int ballCount;

    private void Start()
    {
        ballCount = 1;
        scoreText.text = "0";
        losePanel.SetActive(false);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = amount.ToString();
    }

    public GameObject GetPowerUp()
        => powerUps[UnityEngine.Random.Range(0, powerUps.Length)];

    public void NewBall()
    {
        Vector3 pos = FindObjectOfType<PlatformController>().gameObject.transform.position;
        GameObject newBall = Instantiate(ballPrefab);
        ballCount++;
        newBall.transform.position = new Vector3(pos.x, 0.5f, pos.z + 0.5f);
    }

    public void LoseBall()
    {
        if(--ballCount == 0)
        {
            Lose();
        }
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        scoreText.text = "";
        loseScoreText.text = score.ToString();
    }

    public void RestartLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
