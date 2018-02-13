//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour
{

    //Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };


    //Game State
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    //Random random = new Random();

    //Probably get rid of these
    //string libraryPassword = "book";
    //string policeStationPassword = "handcuffs";
    //string nasaPassword = "hubbletelescope";

    //List<string> pwdList = new List<string>();

    //string guessedPassword;

    // Use this for initialization
    void Start ()
    {
        //pwdList.Add(libraryPassword);
        //pwdList.Add(policeStationPassword);
        //pwdList.Add(nasaPassword);
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") //We can always go direct to main menu
        {
            ShowMainMenu();
        }

        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

        else if (currentScreen == Screen.Password)
        {
            //guessedPassword = input;
            CheckPassword(input);
        }

    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }

        //if (input == "1")
        //{
        //    password = level1Passwords[random.Next(0, level1Passwords.Length)]; // todo make random later
        //    StartGame();
        //}
        //else if (input == "2")
        //{
        //    password = level2Passwords[random.Next(0, level2Passwords.Length)]; // todo make random later
        //    StartGame();
        //}
        //else if (input == "3")
        //{
        //    password = level3Passwords[random.Next(0, level3Passwords.Length)]; // todo make random later
        //    StartGame();
        //}
        else if (input == "007")
        {
            Terminal.WriteLine("Please choose a level, Mr. Bond");
        }
        else if (input == "42")
        {
            Terminal.WriteLine("Such is the answer to the ultimate question of life, the universe and everything, however, you still need to choose a level.");
        }
        else if (input == "Open the pod bay doors, HAL.")
        {
            Terminal.WriteLine("I'm sorry Dave, I'm afraid I can't do that. But you may choose a level.");
        }
        else
        {
            Terminal.WriteLine("I don't know what that is. Please try again.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        // Terminal.WriteLine("You chose level " + level);

        switch (level)
        {
            case 1:
                //password = level1Passwords[random.Next(0, level1Passwords.Length)]; // todo make random later
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                //password = level2Passwords[random.Next(0, level2Passwords.Length)]; // todo make random later
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                //password = level3Passwords[random.Next(0, level3Passwords.Length)]; // todo make random later
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password:");
    }

    void CheckPassword(string input)
    {
        //if (input == pwdList[level - 1])
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("That is incorrect, please try again.");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReqard();
    }

    void ShowLevelReqard()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/
"               );
                break;
            case 2:
                Terminal.WriteLine("Congratulations, you got it Right!");
                break;
            case 3:
                Terminal.WriteLine("Congratulations, you got it Right!");
                break;
            default:
                break;
        }
        
    }
}
