using UnityEngine;

[RequireComponent(typeof(SwingPusher))]
public class Swing : MonoBehaviour
{
    private SwingPusher _swingController;

    private void Awake()
    {
        _swingController = GetComponent<SwingPusher>();
    }

    private void Update()
    {
        _swingController.Push();
    }
}
