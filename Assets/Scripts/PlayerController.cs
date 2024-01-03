using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // private variable '_' before, then camelCase
    // private variable const Uppercase first letter of each word
    // private 
    private const float Speed = 20.0f;
    private const float TurnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;
    
    private const float PositionPositiveLimitedX = 9.4f;
    private const float PositionNegativeLimitedX = -9.4f;

    public int score = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

    // Update is called once per frame (deltaTime is the unit second) 
    void Update()
    {
                _horizontalInput = Input.GetAxis("Horizontal");
                _forwardInput = Input.GetAxis("Vertical");
                if (transform.position.x > PositionPositiveLimitedX || transform.position.x < PositionNegativeLimitedX )
                {
                    EndGame();
                }
                else
                {
                    transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _forwardInput));
                    transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * _horizontalInput);

                }

        
    }
}
