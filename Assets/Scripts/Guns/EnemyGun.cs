using UnityEngine;

public abstract class EnemyGun : Gun

{
    private bool _condition;
    
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    
    protected bool TryShoot()
    {
        Vector2 position = transform.position;
        Ray ray = new Ray(position, Vector2.down);
        RaycastHit2D informationPiso = Physics2D.Raycast(position , ray.direction, 2.0f);

        return informationPiso.collider == null;
    }

 
}
