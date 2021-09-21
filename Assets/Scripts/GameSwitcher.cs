using Assets.Scripts;
using UnityEngine;

public class GameSwitcher : MonoBehaviour
{

    [SerializeField] private SceneTransition _sceneTransition;
    [SerializeField] private DataProvider _dataProvider;
    [SerializeField] private IndicatorPanel _indicatorPanel;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private GameBoard _gameBoard;
    
    private void Start()
    {
        _gameSettings.SetSelectedInfo(_dataProvider);
    }

    public void StartGame()
    {
        _gameBoard.StartSpawnEnemies(_gameSettings.SelectedGun, EndGame);
    }
    
    public void EndGame()
    {
        _dataProvider.SaveData(_indicatorPanel.GetData());
        _sceneTransition.LoadMenu();
        

    }

}
