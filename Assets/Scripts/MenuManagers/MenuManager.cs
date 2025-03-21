using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private float _timer;

    private void Start()
    {
        _timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        foreach(BuildingMenuAnimator building in MainMenu.Menu.Buildings)
        {
            building.Animate();
        }
    }

    public float GetTimer()
    {
        return _timer;
    }
    public void SetTimerTime(float time)
    {
        _timer = time;
    }
}
