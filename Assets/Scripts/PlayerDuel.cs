//PlayerDuel.cs
//Carl Crumer
//Creation Date: October 24 2023
//
// The script the player functions of the game,input, and User Interface
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;

public class PlayerDuel : MonoBehaviour
{
    //Text for instructions, the player's lives, and a time
    //use this 
    public TMP_Text instructionText;
    public TMP_Text livesText;
    public TMP_Text timerText;
    private float gameDuration = 30f;
    private float timer = 0f;
    private bool isRunning = false;
     // 


    //player gets 2 lives, the game lasts for 20 seconds
    private int lives = 2;
    private int hits = 0;
    
    
    private KeyCode action = KeyCode.None;
    private int roundCount = 0;


    //
    private KeyCode[] validInputs = { KeyCode.F, KeyCode.A, KeyCode.Space };


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        UpdateScreen();
    }
    //Updates the user interface,updates the player's lives and time remaining
    private void UpdateScreen()
    {
        livesText.text = "Lives: " + lives;
        timerText.text = "Time: " + (int)(gameDuration - timer);
    }

    //Start the game by initializing game variables, resetting the timer,
    // and displaying the initial instruction. This function is called
    // at the beginning and when the player restarts the game.
    private void StartGame()
    {

        //use this 
        isRunning = true;
        timer = 0f;
        lives = 2;
    }
        // The Update function is called once per frame and handles game state updates,
        // track the timer, check for player input, and ends the game
        // when the timer reaches the game duration. It also updates the user interface.
        void Update()
        {
            //use some of this 
            if (isRunning)
            {
                //timer
                timer += Time.deltaTime;
                UpdateScreen();

                //lose conditions
                if (timer >= gameDuration)
                {
                    isRunning = false;
                    EndGame();
                }
                if (lives == 0)
                {
                    isRunning = false;
                    EndGame();
                }
                if (hits == 2)
                {
                    isRunning = false;
                    EndGame();
                }
            }

        }
        // changes the isRunning boolean to false and changes instruction
        //text on UI to read win or lose, and goes back to main menu
        
        private void EndGame()
        {
            isRunning = false;
            if (hits == 2)
            {
                instructionText.text = "YOU WIN!";
            }
            else
            {
                instructionText.text = "YOU LOSE!";
            }
            EditorSceneManager.LoadScene("MainMenu");


        }
        // CheckInput is called when the player presses a key during an active game.
        // It validates the key pressed against the allowed inputs and provides feedback
        // to the player. If the input is correct, the game continues, but if it's incorrect,
        // the player loses a life, and the game may end if there are no more lives.
        // It also updates the user interface to reflect the result.
        private void CheckInput() {
            KeyCode keyPressed = KeyCode.None;

            if (Input.GetKeyDown(KeyCode.F))
            {
                keyPressed = KeyCode.F;
                Debug.Log("F was pressed");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                keyPressed = KeyCode.A;
                Debug.Log("A");
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                keyPressed = KeyCode.Space;
                Debug.Log("Space");
            }

            IsValidInput(keyPressed);

        }

        //isValidInput checks if the key that the player has entered is the correct key 
        //corresponding to the action given.
        private void IsValidInput(KeyCode keyPressed)
        {
            if (keyPressed == action)
            {
                hits++;
                instructionText.text = "CORRECT!";

            }
            else
            {
                lives--;
                instructionText.text = "MISSED!";

            }

        }
        //returns True if correct is pressed, and false if the key entered is not correct

        // DisplayRandomInstruction is a coroutine that presents a random combat instruction to the player.
        // It sets the instruction text on the user interface, waits for a few seconds, and then updates
        // the text to indicate that the player missed. After a short delay, it prompts the player to get ready
        // for the next instruction.
        private void DisplayRandomInstruction()
        {
            if (roundCount == 0)
            {
                instructionText.text = "READY!";
                instructionText.text = "SET!";
                instructionText.text = "FIGHT!";
            }

            instructionText.text = GetRandomInstruction();
            Debug.Log("Entered Display Random");

        }
        //GetRandomInstruction holds a list of instructions and randomly choses 
        //an instruction to produce for the user
        private string GetRandomInstruction()
        {
            string[] instructions = { "Parry (Press F)", "Block (Press A)", "Attack (Press Space)" };
            int randomIndex = Random.Range(0, instructions.Length);
            Debug.Log(instructions[randomIndex]);
            if (randomIndex == 0)
            {
                action = KeyCode.F;
            }
            if (randomIndex == 1)
            {
                action = KeyCode.A;
            }
            if (randomIndex == 2)
            {
                action = KeyCode.Space;
            }
            Debug.Log("Get Display Random");
            return instructions[randomIndex];

        }


    }

