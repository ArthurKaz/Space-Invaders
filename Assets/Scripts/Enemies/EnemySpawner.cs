using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private Size _enemySpawnSize;
    
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private EnemyFactory _enemyFactory;

    [SerializeField] private float _spawnEnemyTime;

    [SerializeField] private UnityEvent _endWave;
    [SerializeField] private UnityEvent _endGame;

    private float _yPositionEnemyWithGun;

    private Vector2 RightEdgePoint => new Vector2(_spawnPoint.x + _enemySpawnSize.X, _spawnPoint.y);
    private Vector2 LeftEdgePoint => _spawnPoint;

    public UnityAction EndWave
    {
        set => _endWave.AddListener(value);
    }
    
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_spawnPoint,0.2f);
        Vector2 spawnAreaPosition = _spawnPoint;
        spawnAreaPosition.x += (float) _enemySpawnSize.X/2;
        spawnAreaPosition.y -= (float) _enemySpawnSize.Y/2;
        Gizmos.DrawCube(spawnAreaPosition,_enemySpawnSize.GetSpawnArea());
        Gizmos.DrawSphere(RightEdgePoint,0.2f);
    }

    private void SpawnEnemy(int areaOfVision, UnityAction action)
    {
        MoveAllEnemies();
        Enemy enemy = _enemyFactory.GetRandomEnemy(_spawnPoint);

        UnityAction removeElement = delegate
        {
            _enemies.Remove(enemy);
            
        };

        enemy.AddDeadAction(removeElement);
        enemy.AddDeadAction(action);
      
        enemy.Move();
        _enemies.Add(enemy);
       
    }

    private IEnumerator StartSpawner(int areaOfVision, UnityAction action)
    {

        const float TIME_BETWEEN_WAVES = 4;

        yield return new WaitForSeconds(TIME_BETWEEN_WAVES);
        for (int i = 0; i < _enemySpawnSize.AmountOfEnemies; i++)
        {
            SpawnEnemy(areaOfVision, action);
            yield return new WaitForSeconds(_spawnEnemyTime);
        }

        _spawnEnemyTime *= 0.9f;
        _endWave.Invoke();
    }

    private void MoveAllEnemies()
    {

        foreach (Enemy enemy in _enemies)
        {
            enemy.Move();
            if (enemy.IsOnEdges(RightEdgePoint, LeftEdgePoint))
            {
                enemy.MoveDown();
                enemy.SwitchDirection();
                enemy.Move();
                //continue;
            }

            if (enemy.transform.position.y == _spawnPoint.y - _enemySpawnSize.Y)
            {
                _endGame?.Invoke();
            }
        }

    }
    
    public Vector2 GetShipSpawnPoint()
    {
        return new Vector2(_spawnPoint.x + _enemySpawnSize.X / 2, _spawnPoint.y - _enemySpawnSize.Y);
    }
    public void StartSpawn(UnityAction killEnemyAction)
    {
        StartCoroutine(StartSpawner(_enemySpawnSize.Y, killEnemyAction));
        _endWave.AddListener(delegate
        {
            StartCoroutine(StartSpawner(_enemySpawnSize.Y, killEnemyAction));
            
        });
        
    }
 
    
    
    [Serializable]private struct Size
    {
        [Range(1,15)]
        [SerializeField] private int _x;
        [Range(1,10)]
        [SerializeField] private int _y;
        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }
        
        public Vector2 GetSpawnArea()
        {
            return new Vector2(_x, _y);
        }

        public int AmountOfEnemies =>  _x * _y;
    }

  


   
}
