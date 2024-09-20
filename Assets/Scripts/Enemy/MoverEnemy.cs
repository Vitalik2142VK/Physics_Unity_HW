using UnityEngine;

public class MoverEnemy : Mover
{
    [SerializeField] private float _speedMove = 5.0f;
    [SerializeField] private float _speedRotate = 2.0f;

    private Vector3 _point;

    public void SetPoint(Vector3 point)
    {
        _point = point;
    }

    public override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _point, _speedMove * Time.deltaTime);
    }

    public override void Rotate()
    {
        Vector3 direction = (_point - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, _speedRotate * Time.deltaTime);
    }
}
