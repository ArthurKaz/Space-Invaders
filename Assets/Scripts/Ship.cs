using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour, IDieAbleObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health = 3;
    [SerializeField]  private Transform _gunPosition;

    private ShipGun _gun;
    private InformationViewer _shipHealth;
    
    private UnityEvent _endGame = new UnityEvent();
    
    public UnityAction EndGame
    {
        set => _endGame.AddListener(value);
    }
    public ShipGun Gun
    {
        set => _gun = value;
    }
    public InformationViewer ShipHealth
    {
        set
        {
            _shipHealth = value;
            _shipHealth.Info = _health;
        }
    }


    private void Start()
    {
        
        _gun = Instantiate(_gun, _gunPosition.position, Quaternion.identity);
        _gun.transform.SetParent(transform);
        _gun.StartShoots();
    }

    private void Update()
    {
        if (Camera.main != null)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.y = transform.position.y;
            transform.position =
                Vector3.MoveTowards(transform.position, position, _speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.transform.GetComponent<Bullet>().Launched == Bullet.Owner.Enemies) TakeDamage();
       
    }

    public void TakeDamage()
    {
        
        _health--;
        _shipHealth.Info = _health;
        if(_health<= 0) Die();
    }
    public void Die()
    {
        _endGame.Invoke();
    }

    public void AddHealth()
    {
        _health++;
        _shipHealth.Info = _health;
    }
}
