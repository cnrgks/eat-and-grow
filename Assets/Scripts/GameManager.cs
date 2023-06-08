using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    Vector2 spawnPosition = new Vector2(0f, 0f);
    public GameObject mealPrefab;
    public TextMeshProUGUI scoreText;
    [HideInInspector] public int score = 0;

    void Start()
    {
        InvokeRepeating("SpawnMeal", 2f, 0.8f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(1);

        scoreText.text = score.ToString();
    }
    void SpawnMeal()
    {
        Instantiate(mealPrefab, new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f)), Quaternion.identity);
    }
}