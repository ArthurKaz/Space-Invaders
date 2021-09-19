using System.Collections;
using UnityEngine;

public class Cannon : ShipGun
{
    [SerializeField] private Muzzle _rightMuzzle;
    [SerializeField] private Muzzle _leftMuzzle;

    protected override IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_rechargeTime);
            Instantiate(Bullet, _rightMuzzle.Position,Quaternion.identity);
            Instantiate(Bullet, _leftMuzzle.Position,Quaternion.identity);
        }
    }

    public override void SetColor(Color color)
    {
        _rightMuzzle.Color = color;
        _leftMuzzle.Color = color;
    }
}
