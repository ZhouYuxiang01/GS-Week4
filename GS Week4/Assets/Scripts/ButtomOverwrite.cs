using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtomOverwrite : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // ����Ƿ�Ϊ���������
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            base.OnPointerClick(eventData);
        }
    }
}
