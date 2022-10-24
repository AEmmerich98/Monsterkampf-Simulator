using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class SlectableUIObject : MonoBehaviour
{
    //protected MaskableGraphic mObject;

    public UnityEvent mOnConfirm;

    public void Confirm()
    {
        mOnConfirm.Invoke();
    }

    public virtual void Select()
    {

    }

    public virtual void Deselect()
    {

    }
}
