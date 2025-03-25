using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private float _positionOffsetChecker = 0;
    private int _currentBuilding;
    private float _timer;
    private MainMenu _menu;
    private Transform _canvasBG;
    private Quaternion _titleRotation1;
    private Quaternion _titleRotation2;

    [SerializeField] private float _maxTitleRotation;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        _currentBuilding = 0;
        _timer = 0;
        _menu = MainMenu.Menu;
        _canvasBG = _menu.Canvas.transform.Find("BG");
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        RotateTitle();
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

    //TODO: Check this part again

    private void RotateTitle()
    {
        //Quaternion rotation = new Quaternion();
        //rotation.z += 1;
        _menu.RotatingTitle.transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * _rotationSpeed) / (Time.deltaTime * _maxTitleRotation));
        

        //if (_menu.RotatingTitle.transform.rotation.z >= 0)
        //{
        //    _menu.RotatingTitle.transform.rotation = Quaternion.Lerp(_titleRotation1,_titleRotation2, Time.deltaTime);
        //}
        //else
        //{
        //    _menu.RotatingTitle.transform.rotation = Quaternion.Lerp(_titleRotation2, _titleRotation1, Time.deltaTime);
        //}
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
}
