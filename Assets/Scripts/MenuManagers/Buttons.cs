using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool _onEnter = false;
    private bool _onExit = false;

    private TextMeshProUGUI _text;
    private Color _baseColor;
    [SerializeField] private Color _newColor = Color.cyan;




    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _baseColor = _text.color;

    }

    private void Update()
    {
        if (_onEnter)
        {
            _text.color = Color.Lerp(_text.color, _newColor, Time.deltaTime);
        }

        else if (_onExit)
        {
            _text.color = Color.Lerp(_text.color, _baseColor, Time.deltaTime);

        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _onEnter = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        _onEnter = false;
        _onExit = true;
    }
   
    

    public void ButtonStart()
    {
        MainMenu.Menu.MenuManager.SetWasButtonStartPressed();
    }
    public void ButtonOption() 
    {
        MainMenu.Menu.MenuManager.SetWasButtonOptionPressed();
    }
    public void ButtonQuit()
    {
        MainMenu.Menu.MenuManager.SetWasButtonQuitPressed();
    }

    public void ButtonReturn()
    {
        MainMenu.Menu.MenuManager.SetWasButtonReturnPressed();
    }
}
