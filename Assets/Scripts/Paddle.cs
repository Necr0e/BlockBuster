using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float ScreenWidthInUnits = 16f;
    float PaddleMin = 0.8f;
    float PaddleMax = 10f;

    private void Update()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosX, 0.25f);
        paddlePos.x = Mathf.Clamp(mousePosX, PaddleMin, PaddleMax);
        transform.position = paddlePos;
    }
}
