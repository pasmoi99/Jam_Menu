using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuAnimator : SpriteAnimator
{
    // Start is called before the first frame update
    void Start()
    {
        _currentFrame = 0;
        _imageRenderer = GetComponent<Image>();
        _imageRenderer.sprite = _spriteList[0];
        _randModifier = Random.Range(_randModifierMin, _randModifierMax);
    }

    public override void Animate()
    {
        //TODO: change depending on building position
        if (MainMenu.Menu.MenuManager.GetTimer() >= _animationDelay/_randModifier && _currentFrame < _spriteList.Count - 1)
        {
            _imageRenderer.sprite = _spriteList[_currentFrame];
            MainMenu.Menu.MenuManager.SetTimerTime(0);
            if (_currentFrame < _spriteList.Count / 2)
            {
                _animationDelay /= _animationSpeed;
            }
            else 
            {
                _animationDelay *= _animationSpeed;
            }

            _currentFrame = (_currentFrame+1)%_spriteList.Count;
        }        

    }
    public override void SetSize()
    {
        float height = _imageRenderer.rectTransform.rect.height;
        float width = _imageRenderer.rectTransform.rect.width;
        _imageRenderer.rectTransform.sizeDelta = new Vector2(width/_randModifier, height/_randModifier);
    }

    public Sprite GetCurrentSprite()
    {
        return _spriteList[_currentFrame];
    }

    public float GetRandModifier() { return _randModifier; }
    public float GetMoveSpeed() { return _moveSpeed; }
}
