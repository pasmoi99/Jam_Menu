using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private MainMenu _menu;

    [SerializeField] private float _maxTitleRotation = 60;
    [SerializeField] private float _rotationSpeed = 3;

    float _angleToAdd;

    // Start is called before the first frame update
    void Start()
    {
        _menu = MainMenu.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTitle();
    }

    private void RotateTitle()
    {
        _angleToAdd += Time.deltaTime * _rotationSpeed;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(_angleToAdd ) * _maxTitleRotation);
    }
}
