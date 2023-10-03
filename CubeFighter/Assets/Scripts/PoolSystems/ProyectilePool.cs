using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class ProyectilePool : MonoBehaviour
{
    public int poolSize = 5;
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private Proyectile ProyectilePrefabs;
    [SerializeField] private Transform IntialPoint;
    private List<Proyectile> proyectiles = new List<Proyectile>();

    void Start()
    {
        if (ProyectilePrefabs) CreatePoolObjects();
    }

    private void CreatePoolObjects()
    {
        for (int i = 0; i < poolSize; i++)
        {           
            InstantieProyectile();
        }
    }

    public Proyectile GetProyectileFromPool()
    {
        foreach (var proyectile in GetInactiveElements())
        {          
            proyectile.gameObject.SetActive(true);
            return proyectile;           
        }
        return null;
    }

    private void InstantieProyectile()
    {
            var proyectileInstatiated = Instantiate(ProyectilePrefabs, IntialPoint.position, Quaternion.identity);
            proyectileInstatiated.Initialize(this, poolManager);
            proyectileInstatiated.transform.parent = transform;
            proyectileInstatiated.gameObject.SetActive(false);
            proyectiles.Add(proyectileInstatiated);      
    }

    public void RemoveProyectile(Proyectile proyectile)
    {
        proyectile.gameObject.SetActive(false);       
        proyectile.transform.position = IntialPoint.position;
        proyectile.transform.rotation = Quaternion.identity;
    }

    public void RemoveAllProyectiles() => proyectiles
                                            .Where(proy => proy.gameObject.activeSelf).ToList()
                                            .ForEach(p => RemoveProyectile(p));
    
    private IEnumerable<Proyectile> GetInactiveElements() => proyectiles
                                                                .Where(proy => !proy.gameObject.activeSelf);
}
