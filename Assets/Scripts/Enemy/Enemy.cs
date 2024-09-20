using UnityEngine;

[RequireComponent(typeof(MoverEnemy))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private MoverEnemy _mover;

    private void Awake()
    {
        _mover = GetComponent<MoverEnemy>();
    }

    private void FixedUpdate()
    {
        _mover.SetPoint(_target.position);
        _mover.Move();
        _mover.Rotate();
    }
}