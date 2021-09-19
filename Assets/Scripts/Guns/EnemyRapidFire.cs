using System.Collections;
using UnityEngine;

public class EnemyRapidFire : EnemyGun
{
    [SerializeField] private Transform _bulletSpawnPosition;
    
    protected override IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, _rechargeTime));
            if (TryShoot())
            {
                Instantiate(Bullet, _bulletSpawnPosition.position, Quaternion.identity);
                
            }
        }
    }
}
