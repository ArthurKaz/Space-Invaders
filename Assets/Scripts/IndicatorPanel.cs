using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorPanel : MonoBehaviour
{
    
    [SerializeField] private InformationViewer _score= new InformationViewer(0);
    [SerializeField] private InformationViewer _waves = new InformationViewer( 1);
    [SerializeField] private InformationViewer _shipHealth;

    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _BestWaves;

    public InformationViewer ShipHealth => _shipHealth;
    public DataProvider.Data GetData()
    {
        return new DataProvider.Data(1, 1);
    }
    public void AddScore()
    {
        _score.Add();
    }

    public void AddWave()
    {
        _waves.Add();
    }

    public void ShowBestData(DataProvider.Data data)
    {
        _bestScore.text = data.BestScore.ToString();
        _BestWaves.text = data.BestWaves.ToString();
       
    }

}

[Serializable]
public class InformationViewer
{
    [SerializeField] private Text _text;
    private int _info;

    public int Info
    {
        set
        {
            _info = value;
            _text.text = value.ToString();
        }
        get => _info;
    }

    public InformationViewer(int info)
    {
        _info = info;
    }

    public void Add()
    {
        Info++;
    }
}