using UnityEngine;

[RequireComponent(typeof(MoverPlayer))]
public class Player : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move();
        _mover.Rotate();
    }
}
