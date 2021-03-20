using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    private Text _text;

    [SerializeField] private Entity entity;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = $"{entity.Hp}";
    }
}