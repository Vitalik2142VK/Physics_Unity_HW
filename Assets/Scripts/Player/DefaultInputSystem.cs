using UnityEngine;

public class DefaultInputSystem : IInputSystem
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    public float GetHorizontalAxis()
    {
        return Input.GetAxis(Horizontal);
    }

    public float GetVerticalAxis()
    {
        return Input.GetAxis(Vertical);
    }

    public float GetMouseAxisX()
    {
        return Input.GetAxis(MouseX);
    }

    public float GetMouseAxisY()
    {
        return Input.GetAxis(MouseY);
    }
}
