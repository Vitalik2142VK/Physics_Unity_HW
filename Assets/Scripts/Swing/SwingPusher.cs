using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SwingPusher : MonoBehaviour
{
    [SerializeField] private float _forcePush;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _transform = transform;
    }

    public void Push()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 direction = _forcePush * Time.deltaTime * _transform.forward;

            _rigidbody.AddForce(direction * _forcePush);
        }
    }
}
