using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalInput;
    public float verticalInput;
    public string color;
    public int score = 0;
    public GameObject _ballSpawner;
    public Text scoreText;
    public Color playerColor; 

    void Start()
    {
        Renderer playerRenderer = GetComponent<Renderer>();
        playerColor = playerRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(-Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    // Phát hiện va chạm với quả bóng
    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem quả bóng có cùng màu với người chơi hay không
        if (other.GetComponent<Renderer>().material.color == playerColor)
        {
                this.score += 1;
            if (other.gameObject.tag == "RedBall")
            {

                _ballSpawner.GetComponent<BallSpawnerScript>().ballCount[0]--;
                _ballSpawner.GetComponent<BallSpawnerScript>().SpawnBall(0);
            }
            if (other.gameObject.tag == "GreenBall")
            {
                _ballSpawner.GetComponent<BallSpawnerScript>().ballCount[1]--;
                _ballSpawner.GetComponent<BallSpawnerScript>().SpawnBall(1);

            }
            if (other.gameObject.tag == "BlueBall")
            {
                _ballSpawner.GetComponent<BallSpawnerScript>().ballCount[2]--;
                _ballSpawner.GetComponent<BallSpawnerScript>().SpawnBall(2);
            }
            // Ẩn quả bóng
            Destroy(other.gameObject);
            Renderer playerRenderer = GetComponent<Renderer>();
            playerRenderer.material.color = GetRandomColor();   
        }

    }

    public Color GetRandomColor()
    {
        int randomColor = Random.Range(0, 3);
        switch (randomColor)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            default:
                return Color.red;
        }
    }
    
}
