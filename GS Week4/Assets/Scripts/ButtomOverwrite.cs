using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtomOverwrite : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // 检查是否为鼠标左键点击
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerClick(eventData);
        }
    }
}
