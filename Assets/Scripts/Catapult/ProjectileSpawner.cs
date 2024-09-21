using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _spawnPoint;

    private void OnValidate()
    {
        if (_prefab == null)
            throw new ArgumentNullException(nameof(_prefab));

        if (_spawnPoint == null)
            throw new ArgumentNullException(nameof(_spawnPoint));
    }

    public void Spawn()
    {
        Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
    }
}
