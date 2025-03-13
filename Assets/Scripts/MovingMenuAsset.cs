using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingMenuAsset : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _animationSpeed;
    [SerializeField] private float _animationDelay;

    private Image _imageRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _imageRenderer = GetComponent<Image>();
        _imageRenderer.sprite = _spriteList[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-_moveSpeed, 0, 0) * Time.deltaTime;
    }

    void Animate()
    {
        for (int i=1; i < _spriteList.Count; i++)
        {
            _imageRenderer.sprite = _spriteList[i];
        }

    }

}
