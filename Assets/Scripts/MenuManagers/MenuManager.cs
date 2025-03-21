using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private float _positionOffsetChecker = 0;
    private int _currentBuilding;
    private float _timer;

    private void Start()
    {
        _timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (MainMenu.Menu.Buildings.Length <= 3)
        {

        }
        if (MainMenu.Menu.Buildings.Length > 0)
        {

            //_currentBuilding = (_currentBuilding + 1)%;



            //foreach (BuildingMenuAnimator building in MainMenu.Menu.Buildings)
            //{
            //    _positionOffsetChecker = building.GetCurrentSprite().rect.width;
            //    building.Animate();
            //    if (building.transform.position.x < MainMenu.Menu.Canvas.pixelRect.position.x - _positionOffsetChecker)
            //    {
            //        Destroy(building.gameObject);
            //        MainMenu.Menu.Buildings.Remove(building);
            //    }
            //}

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
