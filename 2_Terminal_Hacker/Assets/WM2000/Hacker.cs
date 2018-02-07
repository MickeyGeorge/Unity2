using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour
{

    //Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = { "handcuffs", "jailcell", "blotter", "taser", "squadcar", "criminal" };


    //Game State
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    System.Random random = new System.Random();

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
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[random.Next(0, level1Passwords.Length)]; // todo make random later
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[random.Next(0, level2Passwords.Length)]; // todo make random later
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
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

        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Please enter your password:");

    }

    void CheckPassword(string input)
    {
        //if (input == pwdList[level - 1])
        if (input == password)
            {
            Terminal.WriteLine("Congratulations, you got it Right!");
        }
        else
        {
            Terminal.WriteLine("That is incorrect, please try again.");
        }
    }
}
