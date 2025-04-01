using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuAnimator : SpriteAnimator
{
    private float _timer;
    private float _positionOffsetChecker = 0;

    // Start is called before the first frame update
    void Start()
    {
        _positionOffsetChecker = _spriteList[_currentFrame].rect.width * 2;
        _currentFrame = 0;
        _imageRenderer = GetComponent<Image>();
        _imageRenderer.sprite = _spriteList[0];
        _randModifier = Random.Range(_randModifierMin, _randModifierMax);
        _timer = 0;
        SetSize();
    }
    private void Update()
    {
        Vector3 mov = new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime * _randModifier;
        transform.position += mov;
        Animate();
    }
    public override void Animate()
    {
        if (transform.position.x >= MainMenu.Menu.Canvas.pixelRect.position.x)
        {
            _timer += Time.deltaTime;

            if (_timer >= _animationDelay / _randModifier && _currentFrame < _spriteList.Count - 1)
            {
                _imageRenderer.sprite = _spriteList[_currentFrame];
                _timer = 0;
                if (_currentFrame < _spriteList.Count / 2)
                {
                    _animationDelay /= _animationSpeed;
                }
                else
                {
                    _animationDelay *= _animationSpeed;
                }

                _currentFrame = (_currentFrame + 1) % _spriteList.Count;
            }
        }

    }
    public override void SetSize()
    {
        float height = _imageRenderer.rectTransform.rect.height;
        float width = _imageRenderer.rectTransform.rect.width;
        _imageRenderer.rectTransform.sizeDelta = new Vector2(width / _randModifier, height / _randModifier);
    }

    public Sprite GetCurrentSprite()
    {
        return _spriteList[_currentFrame];
    }

    public float GetPositionOffsetChecker()
    {
        return _positionOffsetChecker;
    }

    public float GetRandModifier() 
    { 
        return _randModifier; 
    }
    public float GetMoveSpeed() 
    { 
        return _moveSpeed;
    }
}
