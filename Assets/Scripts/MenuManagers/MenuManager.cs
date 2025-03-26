using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private float _positionOffsetChecker = 0;
    private int _currentBuilding;
    private float _timer;
    private MainMenu _menu;
    private bool _wasButtonPressed = false;
    private bool _wasFadeIstanceCreated = false;
    private Image fadeTemp;

    [SerializeField] private Transform _canvasBG;
    [SerializeField] private Image _fade;
    
    private void Start()
    {
        _currentBuilding = 0;
        _timer = 0;
        _menu = MainMenu.Menu;
        fadeTemp = _fade;

    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_wasButtonPressed==true)
        {
            
            FadeOut();
        }

        for (int i = 0; i < _menu.Buildings.Length; i++)
        {

            if (_menu.Buildings[_currentBuilding] == null && Random.Range(0, 3) == 0)
            {
                CreateBuilding();
            }


            else if (_menu.Buildings[_currentBuilding] != null)
            {
                ManageBuilding();
            }
            _currentBuilding = (_currentBuilding + 1) % _menu.Buildings.Length;

        }

    }

    private void FadeOut()
    {
        
        if ( _wasFadeIstanceCreated == false)
        {
            _wasFadeIstanceCreated = true;
            fadeTemp=Instantiate(_fade, _menu.Canvas.transform);
            Color col = fadeTemp.color;
            col.a = 0;
            fadeTemp.color = col;

        }
        Color c = fadeTemp.color;
        float t = Time.deltaTime;
        if (c.a + t > 1)
        {
            c.a = 1;
            fadeTemp.color = c;
            _wasButtonPressed = false;
        }
        else
        {
            c.a += t;
            fadeTemp.color = c;
        }
    }

    private void CreateBuilding()
    {
        Vector3 pos = new Vector3(_menu.Canvas.pixelRect.width + _menu.BuildingPrefab.GetCurrentSprite().rect.width, _menu.BuildingPrefab.GetCurrentSprite().rect.width / 2, 0f);
        Quaternion rot = new Quaternion();
        _menu.Buildings[_currentBuilding] = Instantiate(_menu.BuildingPrefab, pos, rot, _canvasBG);
        //_menu.Buildings[_currentBuilding].SetSize();
    }

    private void ManageBuilding()
    {
        _positionOffsetChecker = _menu.Buildings[_currentBuilding].GetCurrentSprite().rect.width * 2;
        Vector3 mov =
            new Vector3(-_menu.Buildings[_currentBuilding].GetMoveSpeed(), 0, 0) * Time.deltaTime * _menu.Buildings[_currentBuilding].GetRandModifier();
        _menu.Buildings[_currentBuilding].transform.position += mov;
        _menu.Buildings[_currentBuilding].Animate();
        if (_menu.Buildings[_currentBuilding].transform.position.x < _menu.Canvas.pixelRect.position.x - _positionOffsetChecker)
        {
            Destroy(_menu.Buildings[_currentBuilding].gameObject);
            _menu.Buildings[_currentBuilding] = null;
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
    public void SetWasButtonPressed()
    {
        _wasButtonPressed = true;
    }
}
