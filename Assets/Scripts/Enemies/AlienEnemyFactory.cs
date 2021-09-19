using Assets.Scripts.Enemies;
using UnityEngine;

public class AlienEnemyFactory : EnemyFactory
{
    [SerializeField] private Alien _octopus, _crab, _jellyfish;

    public override Enemy GetRandomEnemy(Vector2 enemyPosition)
    {
        return GetEnemy((Enemy.EnemyType) Random.Range(0, 3),enemyPosition);
    }
    public override Enemy GetEnemy(Enemy.EnemyType type, Vector2 enemyPosition)
    {
        Enemy enemy = null;
        switch (type)
        {
            case Enemy.EnemyType.Warrior:
                enemy = _octopus;
                break;
            case Enemy.EnemyType.Crab:
                enemy = _crab;
                break;
            case Enemy.EnemyType.Jellyfish:
                enemy = _jellyfish;
                break;
        }

       
        return Instantiate(enemy,enemyPosition,Quaternion.identity);
    }
}
