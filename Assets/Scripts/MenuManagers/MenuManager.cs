using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private float _positionOffsetChecker = 0;
    private int _currentBuilding;
    private float _timer;
    private MainMenu _menu;
    private bool _wasButtonStartPressed = false;
    private bool _wasButtonQuitPressed = false;
    private bool _isInitialFadeOver = false;
    private bool _isFadeRunning = false;


    [SerializeField] private Transform _canvasBG;
    [SerializeField] private Image _imageFade;

    private void Start()
    {
        _currentBuilding = 0;
        _timer = 0;
        _menu = MainMenu.Menu;

    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        #region Fade
        if (_isInitialFadeOver != true)
        {
            FadeIn(_imageFade, 0);
        }


        if (_wasButtonStartPressed == true)
        {
            FadeOut(_imageFade, _wasButtonStartPressed);
        }


        if (_wasButtonQuitPressed == true)
        {
            FadeOut(_imageFade, _wasButtonQuitPressed);
            QuitGame();
        }
        #endregion

        #region Animations
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
        #endregion
    }
    private void FadeIn(Image Fade, int FadeType)
    {
        if (_isFadeRunning == false)
        {
            _isFadeRunning = true;
            Color col = _imageFade.color;
            col.a = 1;
            _imageFade.color = col;
        }

        Color c = Fade.color;
        float t = Time.deltaTime;
        if (c.a - t <= 0)
        {
            c.a = 0;
            Fade.color = c;

            if (FadeType==0)
            {
                _isInitialFadeOver = true;
            }
            //else
            //{
            //    _isInitialFadeOver2 = true;
            //}

            _isFadeRunning = false;
            print("Fade is over");
        }
        else
        {
            c.a -= t;
            Fade.color = c;
        }
    }


    private void FadeOut(Image Fade, bool _buttonPressed)
    {

        if (_isFadeRunning == false)
        {
            _isFadeRunning = true;
            Color col = Fade.color;
            col.a = 0;
            Fade.color = col;
        }

        Color c = Fade.color;
        float t = Time.deltaTime;
        if (c.a + t >= 1)
        {
            c.a = 1;
            Fade.color = c;
            _buttonPressed = false;
            _isFadeRunning = false;

        }
        else
        {
            c.a += t;
            Fade.color = c;
        }
    }


    private void CreateBuilding()
    {
        Vector3 pos = new Vector3(_menu.Canvas.pixelRect.width + _menu.BuildingPrefab.GetCurrentSprite().rect.width, _menu.BuildingPrefab.GetCurrentSprite().rect.height / 2, 0f);
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

    private void QuitGame()
    {
        Application.Quit();
    }

    public float GetTimer()
    {
        return _timer;
    }
    public void SetTimerTime(float time)
    {
        _timer = time;
    }
    public void SetWasButtonStartPressed()
    {
        _wasButtonStartPressed = true;
    }
    public void SetWasButtonQuitPressed()
    {
        _wasButtonQuitPressed = true;
    }
}
