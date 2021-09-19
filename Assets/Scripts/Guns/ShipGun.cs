using System;
using UnityEngine;

public abstract class ShipGun : Gun
{
    public abstract void SetColor(Color color);
    public void StartShoots()
    {
        StartCoroutine(Shoot());
    }
    
    [Serializable] public class Muzzle
    {
        [SerializeField] private Transform _bulletSpawnPosition;

        [SerializeField] private Renderer _muzzleRenderer;
        public Vector3 Position => _bulletSpawnPosition.position;
        public Color Color
        {
            set => _muzzleRenderer.material.color = value;
        }
    }

    
}