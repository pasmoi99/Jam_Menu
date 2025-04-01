using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public void ButtonStart()
    {
        MainMenu.Menu.MenuManager.SetWasButtonStartPressed();
    }
    public void ButtonOption() 
    {
        MainMenu.Menu.MenuManager.SetWasButtonOptionPressed();
    }
    public void ButtonQuit()
    {
        MainMenu.Menu.MenuManager.SetWasButtonQuitPressed();
    }

    public void ButtonReturn()
    {
        MainMenu.Menu.MenuManager.SetWasButtonReturnPressed();
    }
}
