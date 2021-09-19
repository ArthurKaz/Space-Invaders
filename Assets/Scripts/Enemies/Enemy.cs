using Assets.Scripts;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour, IDieAbleObject
{
    
    [SerializeField] private EnemyType _type;
    [SerializeField] private EnemyGun _gun;
    
    protected Direction MoveDirection = Direction.Right;

    private UnityEvent _die = new UnityEvent();
    
    private int _health;
   
    
    private void Awake()
    {
        _die.AddListener(delegate { Destroy(gameObject); });
    }
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.GetComponent<Bullet>().Launched == Bullet.Owner.Player) TakeDamage();
    }

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
          Die();
        }

        
    }

    public void Die()
    {
        _die?.Invoke();
        _die?.RemoveAllListeners();
    }

    public abstract void MoveDown();
    public abstract void Move();
    
   

    public void AddDeadAction(UnityAction action)
    {
        _die.AddListener(action);
    }
    
    public bool IsOnEdges(Vector2 rightEdgePoint, Vector2 leftEdgePoint)
    {
        return rightEdgePoint.x - transform.position.x == 0 || leftEdgePoint.x - transform.position.x == 0;
    }

    public void SwitchDirection()
    {
        if (MoveDirection == Direction.Right) MoveDirection = Direction.Left;
        else MoveDirection = Direction.Right;
    }

    public enum EnemyType
    {
        Warrior = 0,
        Crab = 1,
        Jellyfish = 2
    }

    protected enum Direction
    {
        Left = -1,
        Right= 1
    }
}
