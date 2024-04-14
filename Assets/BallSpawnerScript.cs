using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerScript : MonoBehaviour
{
    // Prefab quả bóng đỏ
    public GameObject redBallPrefab;

    // Prefab quả bóng xanh lục
    public GameObject greenBallPrefab;

    // Prefab quả bóng xanh dương
    public GameObject blueBallPrefab;

    public int[] ballCount = new int[3];

    // Tốc độ sinh ra quả bóng (quả bóng/giây)
    public float spawnRate = 10f;

    // Thời gian chờ trước khi bắt đầu sinh ra quả bóng
    public float startDelay = 0f;

    private float lastSpawnTime = 0f;

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            SpawnBall(i);
            ballCount[i] = 1;
        }
    }

    // Cập nhật mỗi khung hình
    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            SpawnBall(Random.Range(0, 3));
            lastSpawnTime = Time.time;
        }
        for(int i = 0;i < 3;i++) 
        {
            if(ballCount[i] < 1)
            {
                SpawnBall(i);
            }
        }
    }

    // Hàm tạo quả bóng
    public void SpawnBall(int ballType)
    {
        if (ballCount[ballType] < 5)
        {
            // Tạo quả bóng

            Vector3 randomPosition = new Vector3(Random.Range(-25, -15), 1.5f, Random.Range(-30, -20));

            switch (ballType)
            {
                case 0:
                    Instantiate(redBallPrefab, randomPosition, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(greenBallPrefab, randomPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(blueBallPrefab, randomPosition, Quaternion.identity);
                    break;
            }
            ballCount[ballType]++;
        }
    }
}
