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
    public TextMeshProUGUI winScoreText;
    public GameObject losePanel;
    public GameObject winPanel;
    public int objectCount;
    private int score;
    private int ballCount;

    private void Start()
    {
        ballCount = 1;
        scoreText.text = "0";
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        score = 0;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
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

    public void updateObjectNumbers(int change)
    {
        objectCount += change;
        if(objectCount <= 0)
        {
            Win();
        }
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

    public void Win()
    {
        winPanel.SetActive(true);
        scoreText.text = "";
        winScoreText.text = score.ToString();
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
