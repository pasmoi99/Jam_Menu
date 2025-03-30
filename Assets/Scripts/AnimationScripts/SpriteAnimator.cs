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

    [SerializeField, Range(0f,1f)] protected float _randModifierMin;
    [SerializeField, Range(1f, 10f)] protected float _randModifierMax;
    protected float _randModifier;

    protected int _currentFrame;
    protected Image _imageRenderer;

    public virtual void Animate() {
        transform.position += new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
    }

    public virtual void SetSize()
    {
        
    }
}
