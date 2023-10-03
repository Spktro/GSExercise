using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private ProyectilePool SpherePool;
    [SerializeField] private ProyectilePool RectanglePool;

    public Proyectile GetSphereProyectile() => SpherePool.GetProyectileFromPool();
    public Proyectile GetRectangleProyectile() => RectanglePool.GetProyectileFromPool();
    public void RemoveAllSpheres() => SpherePool.RemoveAllProyectiles();
}



