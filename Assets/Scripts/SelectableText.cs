using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectableText : SlectableUIObject
{
    [SerializeField]
    private Color mDefaultColor = Color.white;
    [SerializeField]
    private Color mSelectColor = Color.yellow;

    private TMP_Text mText;

    public void Awake()
    {
        mText = GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string _text)
    {
        mText.text = _text;
    }

    public override void Select()
    {
        mText.color = mSelectColor;
    }

    public override void Deselect()
    {
        mText.color = mDefaultColor;
    }
}
