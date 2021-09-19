using Assets.Scripts;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private RapidFire _rapidFire;
    [SerializeField] private Cannon _cannon;

    private DataProvider.SelectedOptions _selectedOptions ;
    private ShipGun _selectedGun = null;
    
    public ShipGun SelectedGun => _selectedGun;
    
    public void SelectRapidFire()
    {
        Destroy();
        _selectedGun = Instantiate(_rapidFire, Vector2.zero, Quaternion.identity);

        _selectedOptions.SelectedGun = 0;
    }
    public void SelectCannon()
    {
        Destroy();
        _selectedGun = Instantiate(_cannon, Vector2.zero, Quaternion.identity);
        
        _selectedOptions.SelectedGun = 1;
    }

    public void Destroy()
    {
        if(_selectedGun!=null) Destroy(_selectedGun.transform.gameObject);
    }

    public void SetColor(Color color)
    {
        _selectedGun.SetColor(color);
        _selectedOptions.GunColor = color;
    }


    public void SetSelectedInfo(DataProvider dataProvider)
    {
        _selectedOptions = dataProvider.Optionses;
        if (_selectedOptions.SelectedGun == 0) SelectRapidFire();
        if (_selectedOptions.SelectedGun == 1) SelectCannon();
        SetColor(_selectedOptions.GunColor);

    }

    public void SaveOption(DataProvider dataProvider)
    {
        dataProvider.SaveSelectedOptions(_selectedOptions);
    }
}
