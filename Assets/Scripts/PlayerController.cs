using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    private const float Speed = 20.0f;
    private float _playerSpeed = Speed;
    private const float TurnSpeed = 80.0f;
    private float _horizontalInput;
    private float _forwardInput;


    public int score = 0;
    
    public SpawnerBlock spawnerBlock; 
    public SpawnerBonus spawnerBonus;


    private Vector3 _lastSpawnBonus = new Vector3 (0, 0, 0);

    private Vector3 _previousPosition = new Vector3(0, 0, 0);


    void Start()
    {
        InvokeRepeating(nameof(LogicSpawnObject), 0f, 1f);
        InvokeRepeating(nameof(LogicSpeedPlayer), 0f, 0.5f);
    }

    public void IncreaseScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

    }

    public void EndGame(string tagPlayer)
    {
        Debug.Log(tagPlayer);
        PlayerPrefs.SetString("PlayerWin", tagPlayer);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("PlayerWin", "tt"));

        SceneManager.LoadScene("EndGame");
        score = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                if (_playerSpeed > 1)
                {
                    _playerSpeed /= 2.0f;
                }

                IncreaseScore(-10);
                Destroy(other.gameObject);


            }
            else if (other.gameObject.tag == "BonusSpeed")
            {

                if (_playerSpeed <= 40f)
                {
                    _playerSpeed *= 2f;
                }

                IncreaseScore(10);

                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Barrier"))
            {
                var rotation = transform.rotation;
                rotation.y = 0f;
                transform.rotation = rotation;
                transform.position = _previousPosition;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            EndGame(gameObject.tag);
        }
    }


    private void GetSpawnBlock()
    {
        float randomX = Random.Range(-9f, 5f);

        Vector3 spawnPosition = new Vector3(randomX, 2f, transform.position.z + 40f);
        
        spawnerBlock.SpawnBlock(spawnPosition);
    }
    private void GetSpawnBonus()
    {
        float randomX = Random.Range(-9f, 5f);

        _lastSpawnBonus = new Vector3(randomX, 2f, transform.position.z + 30f);

        spawnerBonus.SpawnBonus(_lastSpawnBonus);
    }


    private void MovePlayer()
    {
        if (gameObject.tag == "Player")
        {
            
            _horizontalInput = Input.GetAxis("Horizontal");
            _forwardInput = Input.GetAxis("Vertical");

        }
        else if (gameObject.tag == "Player2")
        {
            _horizontalInput = Input.GetAxis("Horizontal2");
            _forwardInput = Input.GetAxis("Vertical2");
        }
        
        
        if (transform.position.y < -1)
        {
            transform.position = new Vector3(2, 2, 13);
        }
        else
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * _playerSpeed * _forwardInput));
            transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * _horizontalInput);

            _previousPosition = transform.position;

        }
    }

    private void LogicSpeedPlayer()
    {
        if (_playerSpeed > 40f)
        {
            _playerSpeed = 40f;
        } else if (_playerSpeed < 20f)
        {
            _playerSpeed += 1f;
            
        } else if (_playerSpeed > 20f)
        {
            _playerSpeed -= 1f;
        }
        
    }

    private void LogicSpawnObject()
    {
        if (transform.position.z > _lastSpawnBonus.z)
        {
            GetSpawnBonus();
            GetSpawnBlock();
        }
        
        
        
    }
    

    void Update()
    {
        MovePlayer();
    }
}
