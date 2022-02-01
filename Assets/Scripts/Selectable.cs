using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    [SerializeField] private GameObject _button;

    private Color _colorObj;

    private void Start()
    {
        _colorObj = GetComponent<Renderer>().material.color;
    }

    public void Select()
    {
        GetComponent<Renderer>().material.color = new Color(_colorObj.r, _colorObj.g, _colorObj.b, 0.4f);
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material.color = _colorObj;
    }

    public void BuildMenu()
    {
        var _canvas = GameObject.Find("CanvasGame");
        _button.gameObject.SetActive(true);
        _button.transform.SetParent(_canvas.transform);
        _button.GetComponent<RectTransform>().anchorMin = new Vector3(0.5f, 0.5f);
        _button.GetComponent<RectTransform>().anchorMax = new Vector3(0.5f, 0.5f);
        _button.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0);
    }
}
