using System.Collections;
using UnityEngine;

public class RapidFire : ShipGun
{

    [SerializeField] private Muzzle _muzzle;

    protected override IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(_rechargeTime);
            Instantiate(Bullet, _muzzle.Position,Quaternion.identity);
        }
        
    }
    public override void SetColor(Color color)
    {
        _muzzle.Color = color;
    }
}
