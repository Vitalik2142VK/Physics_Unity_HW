using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpringJoint), typeof(Rigidbody), typeof(ProjectileSpawner))]
public class Sling : MonoBehaviour
{
    [SerializeField] private Rigidbody _launchPoint;
    [SerializeField] private Rigidbody _reloadPoint;
    [SerializeField, Range(20.0f, 200.0f)] private float _tensionForceShoot = 50.0f;
    [SerializeField, Min(1.0f)] private float _tensionForceReload = 5.0f;
    [SerializeField, Min(1.0f)] private float _timeReload = 1.0f;

    private ProjectileSpawner _spawner;
    private SpringJoint _joint;
    private State _state;

    private void OnValidate()
    {
        if (_launchPoint == null)
            throw new ArgumentNullException(nameof(_launchPoint));

        if (_reloadPoint == null)
            throw new ArgumentNullException(nameof(_reloadPoint));
    }

    private void Awake()
    {
        _spawner = GetComponent<ProjectileSpawner>();
        _joint = GetComponent<SpringJoint>();

        _state = State.Empty;
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F) && _state == State.ReadyShoot)
        {
            _joint.connectedBody = _launchPoint;
            _joint.spring = _tensionForceShoot;

            _state = State.Empty;
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && _state == State.Empty)
        {
            _joint.connectedBody = _reloadPoint;
            _joint.spring = _tensionForceReload;

            _state = State.Reloading;

            StartCoroutine(WaitRelad());
        }
    }

    private IEnumerator WaitRelad()
    {
        yield return new WaitForSeconds(_timeReload);

        _spawner.Spawn();
        _state = State.ReadyShoot;
    }

    private enum State
    {
        ReadyShoot,
        Empty,
        Reloading
    }
}
