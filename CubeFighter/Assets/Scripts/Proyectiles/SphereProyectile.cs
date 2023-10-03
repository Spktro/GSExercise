using System.Collections;
using UnityEngine;


public class SphereProyectile : Proyectile
{
    private float LinearSpeed = 10f;
    private float AngularSpeed = 7f;
    private Transform target;
    private bool isProjectileMoving = false;

    public override void Fire(Transform target)
    {
        this.target = target;
        isProjectileMoving = true;
        StartCoroutine(MoveProjectile());
    }

    private IEnumerator MoveProjectile()
    {
        while (isProjectileMoving)
        {
            if (target != null)
            {
                Vector3 direction = GetTargetDirection();
                Quaternion rotation = GetTargetRotation(direction);
                AdvanceStepTo(direction);
                RotateTo(rotation);
            }
            yield return null;
        }
    }

    private Quaternion GetTargetRotation(Vector3 direction) => Quaternion.LookRotation(direction);
    private Vector3 GetTargetDirection() => (target.transform.position - transform.position).normalized;
    private void RotateTo(Quaternion rotation) => transform.rotation = Quaternion.Slerp(transform.rotation, rotation, AngularSpeed * Time.deltaTime);
    private void AdvanceStepTo(Vector3 direction) => transform.position += direction * LinearSpeed * Time.deltaTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            isProjectileMoving = false;
            StopCoroutine(MoveProjectile());
            proyectilePool.RemoveProyectile(this);
        }
    }
}



