using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuAsset : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _animationSpeed;
    [SerializeField] private float _animationDelay;


    private int _currentFrame;
    private float _timer;

    private Image _imageRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _currentFrame = 0;
        _imageRenderer = GetComponent<Image>();
        _imageRenderer.sprite = _spriteList[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
        _timer += Time.deltaTime;
        Animate();
    }

    void Animate()
    {
        if (_timer >= _animationDelay && _currentFrame < _spriteList.Count - 1)
        {
            _imageRenderer.sprite = _spriteList[_currentFrame];
            _timer = 0;
            _currentFrame = (_currentFrame+1)%_spriteList.Count;
        }        

    }

}
