using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyFollow
{

    public int damage = 10;
    public GameObject bullet;
    public float bulletForce;
    public Transform enemyShotPoint;
    public Transform gun;
    Vector2 gunDirection;


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        AimGun();
    }

    protected override void Attack()
    {
        base.Attack();
        
        Shoot();
    }

    void Shoot()
    {
        Vector3 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject newBullet = Instantiate(bullet, enemyShotPoint.position, q);

    }
    void AimGun()
    {
        Vector3 gunDirection = (target.position - gun.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (gunDirection.x < gun.position.x)
        {
            gun.rotation = Quaternion.Euler(0, 180, (180 - angle));
        }
    }

}
