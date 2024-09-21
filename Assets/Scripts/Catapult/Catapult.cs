using System;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Sling _sling;

    private void OnValidate()
    {
        if (_sling == null)
            throw new ArgumentNullException(nameof(_sling));
    }

    private void Update()
    {
        _sling.Shoot();
        _sling.Reload();
    }
}
