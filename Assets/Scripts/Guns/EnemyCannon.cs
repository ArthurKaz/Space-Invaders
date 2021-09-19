using System.Collections;
using UnityEngine;

public class EnemyCannon : EnemyGun
{
    [SerializeField] private Transform _rightBulletSpawnPosition;
    [SerializeField] private Transform _leftBulletSpawnPosition;

    protected override IEnumerator Shoot()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(1, _rechargeTime));
            if (TryShoot())
            {
                Instantiate(Bullet, _rightBulletSpawnPosition.position, Quaternion.identity);
                Instantiate(Bullet, _leftBulletSpawnPosition.position, Quaternion.identity);
            }
        }
    }
}