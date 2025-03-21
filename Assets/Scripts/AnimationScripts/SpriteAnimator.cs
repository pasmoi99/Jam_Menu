using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] protected List<Sprite> _spriteList;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] protected float _animationSpeed;
    [SerializeField] protected float _animationDelay;


    protected int _currentFrame;
    protected Image _imageRenderer;

    public virtual void Animate() { 
    }
}
