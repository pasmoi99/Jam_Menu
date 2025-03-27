using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public void ButtonStart()
    {
        MainMenu.Menu.MenuManager.SetWasButtonStartPressed();
        print("start");
    }
    public void ButtonOption() 
    {
        
    }
    public void ButtonQuit()
    {
        MainMenu.Menu.MenuManager.SetWasButtonQuitPressed();
    }
}
