using UnityEngine;
using UnityEngine.Events;

public class GameBoard : MonoBehaviour
{
        [SerializeField] private IndicatorPanel _indicatorPanel;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Ship _ship;

        public Vector2 ShipSpawnPosition => _enemySpawner.GetShipSpawnPoint();

        public void StartSpawnEnemies(ShipGun gun, UnityAction endGame)
        {
                _enemySpawner.StartSpawn(delegate { _indicatorPanel.AddScore(); });

                _ship = Instantiate(_ship, ShipSpawnPosition, Quaternion.identity);
                _ship.Gun = gun;
                _ship.EndGame = endGame;
                _ship.ShipHealth = _indicatorPanel.ShipHealth;
        }

        public void AddHealthForShip()
        {
                _ship.AddHealth();
        }
}
