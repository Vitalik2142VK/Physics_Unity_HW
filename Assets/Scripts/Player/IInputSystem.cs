using UnityEngine;

public interface IInputSystem
{
    float GetHorizontalAxis();

    float GetVerticalAxis();

    float GetMouseAxisX();

    float GetMouseAxisY();
}