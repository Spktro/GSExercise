using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private Transform Target;
        public void Fire()
        {
            SpawnRectangle();
        }

        private void SpawnRectangle()
        {
            var proyectile = poolManager.GetRectangleProyectile();
            proyectile?.Fire(Target);
        }
       
    }
}