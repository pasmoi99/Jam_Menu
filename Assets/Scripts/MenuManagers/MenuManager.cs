using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private int _currentBuilding;

    private MainMenu _menu;

    private bool _wasButtonStartPressed = false;
    private bool _isTransitionOptionRunning = false;
    private bool _wasButtonOptionPressed = false;
    private bool _wasButtonQuitPressed = false;
    private bool _wasButtonReturnPressed = false;

    private bool _isInitialFadeOver = false;
    private bool _isFadeRunning = false;

    private bool _hasGameStarted = false;

    private bool _wasMainMenuCleaned = false;
    private bool _isInOptions = false;

    [SerializeField] private Transform _canvasBG;
    [SerializeField] private Image _imageFade;
    [SerializeField] private GameObject _optionBG;
    [SerializeField,Range(0f,2f)] private float _fadeSpeed;

    private void Start()
    {
        _currentBuilding = 0;
        _menu = MainMenu.Menu;


    }

    void Update()
    {

        #region Fade
        if (_isInitialFadeOver == false)
        {
            _imageFade.gameObject.SetActive(true);
            FadeIn(0);
        }


        if (_wasButtonStartPressed == true)
        {
            _imageFade.gameObject.SetActive(true);
            FadeOut(0);
            if (_isFadeRunning == false)
            {
                QuitGame();
            }
        }

        if (_wasButtonOptionPressed == true || _wasButtonReturnPressed==true)
        {
            if (_isTransitionOptionRunning == false)
            {
                _imageFade.gameObject.SetActive(true);
                FadeOut(1);
            }
            else
            {
                FadeIn(1);
            }
        }

        if (_wasButtonQuitPressed == true)
        {
            _imageFade.gameObject.SetActive(true);
            FadeOut(2);
            if (_isFadeRunning == false)
            {
                //print("Quit");
                QuitGame();
            }
        }
        #endregion

        #region Buildings
        if (_isInOptions == false)
        {
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
            _wasMainMenuCleaned = false;

        }
        else
        {
            if (_wasMainMenuCleaned == false)
            {
                for (int i = 0; i < _menu.Buildings.Length; i++)
                {
                    if (_menu.Buildings[i] != null)
                    {
                        Destroy(_menu.Buildings[i].gameObject);
                        _menu.Buildings[i] = null;
                    }

                }
                _wasMainMenuCleaned = true;
            }
        }

        #endregion

        #region Palmtrees



        #endregion

        #region Options
        if (_isInOptions)
        {
            _menu.RotatingTitle.SetActive(false);
            _menu.Options.SetActive(true);
            _optionBG.SetActive(true);
        }
        else
        {
            _menu.RotatingTitle.SetActive(true);
            _menu.Options.SetActive(false);
            _optionBG.SetActive(false);
        }
        #endregion

    }
    private void FadeIn(int FadeValue)
    {
        if (_isFadeRunning == false)
        {
            _isFadeRunning = true;
            Color col = _imageFade.color;
            col.a = 1;
            _imageFade.color = col;
        }

        Color c = _imageFade.color;
        float t = Time.deltaTime;
        if (c.a - t <= 0)
        {
            c.a = 0;
            _imageFade.color = c;
            if (FadeValue == 0)
            {
                _isInitialFadeOver = true;
                _imageFade.gameObject.SetActive(false);
            }
            else if (FadeValue == 1)
            {
                _wasButtonOptionPressed = false;
                _wasButtonReturnPressed = false;
                _isTransitionOptionRunning = false;
                _imageFade.gameObject.SetActive(false);
            }

            _isFadeRunning = false;
        }
        else
        {
            c.a -= t * _fadeSpeed;
            _imageFade.color = c;
        }
    }


    private void FadeOut(int FadeValue)
    {

        if (_isFadeRunning == false)
        {
            _isFadeRunning = true;
            Color col = _imageFade.color;
            col.a = 0;
            _imageFade.color = col;
        }

        Color c = _imageFade.color;
        float t = Time.deltaTime;
        if (c.a + t >= 1)
        {
            c.a = 1;
            _imageFade.color = c;
            if (FadeValue == 0)
            {
                _wasButtonStartPressed = false;
                _isFadeRunning = false;
                _hasGameStarted = true;
            }
            else if (FadeValue == 1)
            {
                _isTransitionOptionRunning = true;
                _isInOptions = !_isInOptions;
            }
            else if (FadeValue == 2)
            {
                _wasButtonQuitPressed = false;
                _isFadeRunning = false;
            }


        }
        else
        {
            c.a += t*_fadeSpeed;
            _imageFade.color = c;
        }
    }


    private void CreateBuilding()
    {
        Vector3 pos =
            new Vector3(_menu.Canvas.pixelRect.width + _menu.BuildingPrefab.GetCurrentSprite().rect.width, _menu.BuildingPrefab.GetCurrentSprite().rect.height, 0f);
        Quaternion rot = new Quaternion();
        _menu.Buildings[_currentBuilding] = Instantiate(_menu.BuildingPrefab, pos, rot, _canvasBG);

    }

    private void ManageBuilding()
    {

        if (_menu.Buildings[_currentBuilding].transform.position.x < _menu.Canvas.pixelRect.position.x - _menu.Buildings[_currentBuilding].GetPositionOffsetChecker())
        {
            Destroy(_menu.Buildings[_currentBuilding].gameObject);
            _menu.Buildings[_currentBuilding] = null;
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void SetWasButtonStartPressed()
    {
        _wasButtonStartPressed = true;
    }

    public void SetWasButtonOptionPressed()
    {
        _wasButtonOptionPressed = true;
    }
    public void SetWasButtonQuitPressed()
    {
        _wasButtonQuitPressed = true;
    }
    public void SetWasButtonReturnPressed()
    {
        _wasButtonReturnPressed = true;
    }

    public bool GetHasGameStarted()
    {
        return _hasGameStarted;
    }
}
