using System.Collections;
using Assets.Scripts;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
   [SerializeField] protected float _rechargeTime;
   [SerializeField] protected Bullet Bullet;
   
 
   
   protected abstract IEnumerator Shoot();


  
}
