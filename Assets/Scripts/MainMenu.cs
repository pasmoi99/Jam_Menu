using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Menu { get; private set; }
    public MenuManager MenuManager;
    public List<BuildingMenuAnimator> Buildings;


    void Awake()
    {
        Menu = this;
    }
}
