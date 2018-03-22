using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class JoystickControl : MonoBehaviour , IDragHandler , IPointerDownHandler {
    private Image bgImg;
    private Image JoystickImage;
    private Vector3 InputVector;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        JoystickImage = transform.GetChild(0).GetComponent<Image>();

    }

    public virtual void OnDrag(PointerEventData PED)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,PED.position,PED.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            InputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            if(InputVector.magnitude>1.0f)
            { InputVector = InputVector.normalized; }
            else { InputVector = InputVector; }
            JoystickImage.rectTransform.anchoredPosition = new Vector3(InputVector.x * (bgImg.rectTransform.sizeDelta.x / 3),
                                                                        InputVector.y * (bgImg.rectTransform.sizeDelta.y / 3) );
            
        }

    }
    public virtual void OnPointerDown(PointerEventData PED)
    {
        OnDrag(PED);
    }

    public float JoystickAngle()
    {
        double Angle = Math.Atan2(InputVector.x, InputVector.y) * (180 / Math.PI);
        return (float)Angle;
    }

}
