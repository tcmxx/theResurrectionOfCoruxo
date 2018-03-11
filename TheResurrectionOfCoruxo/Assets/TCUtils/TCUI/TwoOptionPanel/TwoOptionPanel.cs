﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoOptionPanel : MonoBehaviour {

    [Header("Reference")]
    public Button leftButtonRef;
    public Button rightButtonRef;
    public Text leftTextRef;
    public Text rightTextRef;
    public Text mainTextRef;


    protected Action onLeftButtonDown;
    protected Action onRightButtonDown;

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
	
    public void StartOptionPanel(string leftText, Action onLeftClicked, string rightText, Action onRightClicked, string mainText, bool defaultLeft = true)
    {
        if (leftText != null || onLeftClicked != null)
        {
            leftButtonRef.gameObject.SetActive(true);
            leftButtonRef.onClick.RemoveAllListeners();
            leftButtonRef.onClick.AddListener(new UnityEngine.Events.UnityAction(onLeftClicked));
            leftTextRef.text = leftText;
        }
        else
        {
            leftButtonRef.gameObject.SetActive(false);
        }
        if (rightText != null || onRightClicked != null)
        {
            rightButtonRef.gameObject.SetActive(true);
            rightButtonRef.onClick.RemoveAllListeners();
            rightButtonRef.onClick.AddListener(new UnityEngine.Events.UnityAction(onRightClicked));
            rightTextRef.text = rightText;
        }
        else
        {

            rightButtonRef.gameObject.SetActive(false);
        }
        mainTextRef.text = mainText;

        gameObject.SetActive(true);

        (defaultLeft ? leftButtonRef : rightButtonRef).Select();
    }

}
