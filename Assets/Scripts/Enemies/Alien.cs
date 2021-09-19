using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Alien : Enemy
    {
        public override void MoveDown()
        {
            Vector2 newPosition= transform.position;
            newPosition.y -= 1;
            transform.position = newPosition;
        }

        public override void Move()
        {
            Vector2 newPosition= transform.position;
            newPosition.x += (float) MoveDirection;
            transform.position = newPosition;
        }
    }
}
