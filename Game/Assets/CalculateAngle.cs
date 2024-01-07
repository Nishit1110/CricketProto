using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalculateAngle : MonoBehaviour , IBeginDragHandler, IDragHandler , IEndDragHandler
{
    Vector3 firstPos;
    Vector3 lastPos;
    [SerializeField] InputBat bat;

    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPos = eventData.position;
        firstPos.z = firstPos.y;
        firstPos.y = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        lastPos = eventData.position;
        lastPos.z = lastPos.y;
        lastPos.y = 0;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        bat.calculateDir(firstPos, lastPos);
    }
}
