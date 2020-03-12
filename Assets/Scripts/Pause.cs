using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenu;
    public GameObject tutorial;
    public GameObject hud;

    public Image leftButton;

    public Image[] tutorialImages;

    bool healthInitialized = false;
    public bool tutorialDone = false;
    public bool isGameWon;

    //Text that shows the players stats
    public TextMeshProUGUI playerStats;

    //Text that shows what state the player is in
    public TextMeshProUGUI stateIndicator;

    //Text that shows messages for the player
    public TextMeshProUGUI errorMessage;

    public TextMeshProUGUI instructions;

    public TextMeshProUGUI enemyStats;

    //The number is used to differentiate between instruction pieces.
    private int instructionNumber;
    //The flag is used to determine if we actually need to stop. First portion only.
    private bool instructionFlag;
    //This flag is used to see if the instructions are accessed through the pause menu.
    private bool throughPause = false;

    private void Start()
    {
        instructionNumber = 1;
        instructionFlag = false;
        isGameWon = false;
    }

    //Resumes the game from the pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Reactivates the player
        ReenablePlayer();
    }

    //Used on the pause menu to pause the game
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //Deactivates player
        DisablePlayer();
    }

    //Used on the pause menu to get back to the main menu
    public void QuitGame()
    {
        Resume();

        //This resets the tutorial
        throughPause = false;
        TutorialReset();


    }

    //Displays error messages to the player when they are out of mana and stuff like that
    //Takes in a string that is flashed in red at the top of the screen
    public IEnumerator DisplayError(string error)
    {
        errorMessage.text = error;
        errorMessage.CrossFadeAlpha(1, 0.5f, false);
        yield return new WaitForSeconds(1f);
        errorMessage.CrossFadeAlpha(0, 0.5f, false);
    }

    void Update()
    {
        //Makes sure that you can't open the pause menu when in the settings menu, gameover screen, or level up screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingMenu.activeSelf == false)
            {
                if (GameIsPaused)
                {
                    //This checks to see if the pause menu is turned on. It is used for the instructions/tutorial
                    throughPause = false;
                    TutorialReset();
                    Resume();
                }
                else
                {
                    throughPause = true;
                    pause();
                }
            }

        }


    }
    public void Tutorial()
    {

        if (!throughPause)
        {
            //Checks to see if we need to pause/unpause
            if (instructionFlag || (instructionNumber > 6))
            {

                //Disables the paused portion
                tutorial.SetActive(false);
                Time.timeScale = 1;
                ReenablePlayer();
                //These are used to help the tutorial flow with the break in the middle

                if (instructionNumber > 6)
                {
                    tutorialDone = true;
                    TutorialReset();
                }
                else if (instructionFlag)
                {
                    instructionFlag = false;
                }

            }
            else
            {
                //Pauses the game
                tutorial.SetActive(true);
                Time.timeScale = 0;
                hud.SetActive(false);
                //Makes sure this only fires when the first tutorial is over
                if (instructionNumber == 1 && !tutorialDone)
                {
                    //Resets the instruction flag
                    instructionFlag = true;
                }

                //This ensures it doesn't break the first tutorial bit.
                if (instructionNumber != 2)
                {
                    DisablePlayer();
                }
            }
        }
        else
        {
            if (tutorialDone)
            {
                //When you finish the tutorial again.
                if (instructionNumber > 6)
                {
                    //This is only if it is paused. This will make the pause menu come up again.
                    TutorialReset();
                }
                else if (instructionNumber == 1)
                {
                    tutorial.SetActive(true);
                    pauseMenuUI.SetActive(false);
                }
            }

        }
        //Switch statement to walk through each piece of instruction
        switch (instructionNumber)
        {
            case 1:

                instructions.text = "Use WASD to move in free movement mode";
                tutorialImages[0].enabled = true;
                tutorialImages[1].enabled = false;
                tutorialImages[2].enabled = false;
                tutorialImages[3].enabled = false;
                leftButton.enabled = false;

                break;
            case 2:

                instructions.text = "Once you enter the combat zone, you can move by moving the mouse and clicking. The line shows your path, and is green when you can move to that spot. You only have a limited amount of movement per turn, so use it strategically!";
                //Changes the images
                tutorialImages[0].enabled = false;
                tutorialImages[1].enabled = true;
                tutorialImages[2].enabled = true;
                tutorialImages[3].enabled = true;
                tutorialImages[4].enabled = false;
                tutorialImages[5].enabled = false;

                if (!throughPause)
                {
                    //If the tutorial is accessed not through the pause menu, it will use this section of code
                    leftButton.enabled = false;
                }
                else
                {
                    leftButton.enabled = true;
                }

                break;
            case 3:

                instructions.text = "You can also use the mouse to use melee attacks. The attack will only hit when it is over the enemy. Be warned: You can only use one melee attack per turn.";
                //Changes the images... again
                tutorialImages[1].enabled = false;
                tutorialImages[2].enabled = false;
                tutorialImages[3].enabled = false;
                tutorialImages[4].enabled = true;
                tutorialImages[5].enabled = true;
                tutorialImages[6].enabled = false;
                tutorialImages[7].enabled = false;
                //This will be enabled regardless of the mode used, so don't worry about it.
                leftButton.enabled = true;

                break;
            case 4:

                instructions.text = "Another option for an attack is a ranged mage attack. You can use as many of these as you want per turn, assuming you have enough mana.";
                tutorialImages[4].enabled = false;
                tutorialImages[5].enabled = false;
                tutorialImages[6].enabled = true;
                tutorialImages[7].enabled = true;
                tutorialImages[8].enabled = false;

                break;
            case 5:

                instructions.text = "Your final option is to use a shield. A shield gives you one extra hit point, but costs mana to use. You can only have one shield active at a time.";
                tutorialImages[6].enabled = false;
                tutorialImages[7].enabled = false;
                tutorialImages[8].enabled = true;

                break;
            case 6:

                instructions.text = "Use the scroll wheel to switch between all of these options. Hit \"Esc\" to open up the pause menu, which will let you review these instructions, and hit \"Enter\" to end your turn.";
                tutorialImages[8].enabled = false;

                break;
        }
    }
    public void TutorialLeft()
    {
        if (instructionNumber > 1)
        {
            //Moves left
            instructionNumber--;
        }

        Tutorial();
    }

    public void TutorialRight()
    {
        if (instructionNumber < 7)
        {
            //Moves Right
            instructionNumber++;
        }

        Tutorial();
    }

    private void TutorialReset()
    {

        //This will deactivate the tutorial stuff
        tutorial.SetActive(false);
        //Resets the instruction flag if this is not accessed through the pause menu.
        if (!throughPause)
        {
            instructionFlag = true;
        }
        else
        {
            pauseMenuUI.SetActive(true);
        }

        //Resets the instruction number.
        instructionNumber = 1;
    }

    public void WinGame()
    {
        isGameWon = true;
    }

    //Reenables the player
    private void ReenablePlayer()
    {

    }

    //Disables the player
    private void DisablePlayer()
    {

    }


}
