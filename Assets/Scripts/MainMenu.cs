using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Menu { get; private set; }
    public MenuManager MenuManager;
    public BuildingMenuAnimator BuildingPrefab;
    public BuildingMenuAnimator[] Buildings;
    public Canvas Canvas;


    void Awake()
    {
        Menu = this;
    }

    private void Start()
    {
        Buildings = new BuildingMenuAnimator[3];
    }
}
