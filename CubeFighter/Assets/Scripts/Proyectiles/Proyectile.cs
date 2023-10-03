using System;
using UnityEngine;

public abstract class Proyectile : MonoBehaviour
{
    protected ProyectilePool proyectilePool;
    protected PoolManager poolManager;
    public void Initialize(ProyectilePool proyectilePool, PoolManager poolManager)
    {
        this.proyectilePool = proyectilePool;
        this.poolManager = poolManager;
    }
    public abstract void Fire(Transform target);  
}

