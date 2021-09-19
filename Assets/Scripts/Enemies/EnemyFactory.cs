using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract Enemy GetRandomEnemy(Vector2 enemyPosition);
    public abstract Enemy GetEnemy(Enemy.EnemyType type, Vector2 enemyPosition);
}
