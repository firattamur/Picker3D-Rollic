﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    [SerializeField] MenuController menuController;
    [SerializeField] float dragThresholdforStart = 0.10f;

    private GameState gameState;

    public static GameController instance;

    // Singleton Initialization
    void Awake()
    {
        if (!GameController.instance)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {   

        // start game with menu state
        gameState = GameState.MENU;

    }

    // Update is called once per frame
    void Update()
    {
        
        // if horizontal move then start game
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > dragThresholdforStart){
            StartGame();
        }

    }

    public void SetState(GameState state)
    {
        gameState = state;
    }

    public GameState GetState()
    {
        return gameState;
    }

    private void StartGame()
    {

        // remove menu elements before start game
        menuController.UnDisplayMenuElements();

        // change state to play to start game
        gameState = GameState.PLAY;

    }

    private void LoseGame()
    {

        // pause game and bring lose screen elements
        

        // change state to lose
        gameState = GameState.LOSE;
        
    }


}
