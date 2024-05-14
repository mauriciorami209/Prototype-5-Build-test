using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int lives;
    private float score;
    public bool isActiveGame;
    public GameObject titleScreen;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isActiveGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
          
        }
    }

  public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
    }

    public void UpdateLives(int LivesToChange)
    {
        lives += LivesToChange;
        livesText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            GameOver();
            livesText.text = "Lives: " + 0;        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isActiveGame = false;
       // titleScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Prototype 5");
    }

    public void StartGame(int difficulty)
    {
        isActiveGame = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;

    }
}
