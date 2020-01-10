using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBounds;
    public EnemyController enemyPrefab;

    private HUDController hUDController;
    private int totalPoints;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        hUDController = FindObjectOfType<HUDController>();
        playerSpeed = 10;
        screenBounds = GetScreenBounds();
        //Debug.Log("screenBounds.x=" + screenBounds.x);
        //Debug.Log("screenBounds.y=" + screenBounds.y);
        StartCoroutine(SpawnEnemies());
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SetColor(Color.red);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.SetColor(Color.yellow);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            enemy.EnemyEscaped += EnemyAtBottom;
            enemy.EnemyKilled += EnemyKilled;

            yield return wait;
        }
    }

    private void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue;
        hUDController.scoreText.text = totalPoints.ToString();
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy Escaped");
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        //Debug.Log("screen.width=" + screenVector.x);


        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    public void KillObject(IKillable killable)
    {
        Debug.LogWarningFormat("{0} killed by GameSceneController", killable.GetName());
        killable.Kill();
    }
}
