using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RectangleProyectile : Proyectile
{
    [SerializeField] private ProyectilePool SpherePool;  
    private Rigidbody rigidBody;
    public Transform Target;
    private float force = 1000f;
    public override void Fire(Transform target)
    {
        this.Target = target;
        rigidBody = GetComponent<Rigidbody>();
        MoveProyectile();
    }

    private void MoveProyectile() => rigidBody.AddForce(Vector3.forward * force);

    private void SpawnSphere()
    {
        var proyectile = poolManager.GetSphereProyectile();        
        proyectile?.Fire(Target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            SpawnSphere();
            proyectilePool.RemoveProyectile(this);
        }
    }
}
