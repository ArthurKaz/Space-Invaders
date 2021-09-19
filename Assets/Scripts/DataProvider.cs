using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataProvider : MonoBehaviour
    {
        [SerializeField] private Data _bestData;
        [SerializeField] private SelectedOptions _selectedOptions;
        [SerializeField] private IndicatorPanel _indicatorPanel;
        
        private string _dataPath;
        private string _selectedOptionsPath;
        
        public SelectedOptions Optionses => _selectedOptions;

        private void Awake()
        {

            _dataPath = Application.persistentDataPath + "/Data.json";
            _selectedOptionsPath = Application.persistentDataPath + "/Optionses.json";
            
            LoadData();
            LoadSelectedOption();
            _indicatorPanel.ShowBestData(_bestData);
            
           
        }

        private void LoadData()
        {
            if(File.Exists(_dataPath)) _bestData = JsonUtility.FromJson<Data>(File.ReadAllText(_dataPath));
            else _bestData = new Data(1, 1);
        }
        
        public void SaveData(Data data)
        {
            _bestData.SetNewBestData(data);
            File.WriteAllText(_dataPath,JsonUtility.ToJson(_bestData));
        }

        private void LoadSelectedOption()
        {
            if (File.Exists(_selectedOptionsPath))
                _selectedOptions = JsonUtility.FromJson<SelectedOptions>(File.ReadAllText(_selectedOptionsPath));
            else _selectedOptions = new SelectedOptions();
            
        }
        
        public void SaveSelectedOptions(SelectedOptions selectedOptions)
        {
            File.WriteAllText(_selectedOptionsPath,JsonUtility.ToJson(selectedOptions));
        }
    
        [Serializable]
        public class Data
        {
            [SerializeField] private int _bestScore;
            [SerializeField] private int _bestWaves;

            public int BestScore
            {
                get => _bestScore;
                set => _bestScore = value > _bestScore ? value : _bestScore;
            }

            public int BestWaves
            {
                get => _bestWaves;
                set => _bestWaves = value > _bestWaves? value :_bestWaves;
            }

            public Data(int bestScore, int bestWaves)
            {
                _bestScore = bestScore;
                _bestWaves = bestWaves;
            }

            public void SetNewBestData(Data data)
            {
                if (data._bestScore > _bestScore) _bestScore = data._bestScore;
                if (data.BestWaves > _bestWaves) _bestWaves = data._bestWaves;
            }
            
            
        }

        [Serializable] public class SelectedOptions
        {
            [SerializeField] private Color _gunColor;
            [SerializeField] private int _selectedGun;
            public Color GunColor
            {
                get => _gunColor;
                set => _gunColor = value;
            }

            public int SelectedGun
            {
                get => _selectedGun;
                set => _selectedGun = value;
            }

            public SelectedOptions(int selectedGun, Color gunColor)
            {
                _gunColor = gunColor;
                _selectedGun = selectedGun;
            }

            public SelectedOptions()
            {
                _selectedGun = 0;
                _gunColor = Color.red;
            }
        }

       
    }
}
