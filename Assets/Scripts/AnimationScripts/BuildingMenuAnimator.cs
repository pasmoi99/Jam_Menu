using System.Collections.Generic;
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
    }

    public override void Animate()
    {
        transform.position += new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
        if (MainMenu.Menu.MenuManager.GetTimer() >= _animationDelay && _currentFrame < _spriteList.Count - 1)
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

}
