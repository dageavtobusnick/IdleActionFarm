using System;
using UnityEngine;

public static class CanvasExtension 
{
   public static Vector2 WorldToCanvasPosition(this Canvas canvas,Camera camera,Vector3 position)
   {
        var rectTransform=canvas.GetComponent<RectTransform>();
        var viewPortPosition=camera.WorldToViewportPoint(position);
        viewPortPosition.x*=rectTransform.sizeDelta.x;
        viewPortPosition.y*=rectTransform.sizeDelta.y;
        viewPortPosition.x-=rectTransform.sizeDelta.x*rectTransform.pivot.x;
        viewPortPosition.y-=rectTransform.sizeDelta.y*rectTransform.pivot.y;
        return new Vector2(viewPortPosition.x, viewPortPosition.y);
   }
}
