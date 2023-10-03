using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private PoolManager PoolManger;               
        [SerializeField] private Transform Target;
        [SerializeField] private float fireRate = 1f;        
        private bool IsFire = false;
        private Coroutine firingCoroutine;

        public void Fire() 
        {
            if (!IsFire)
            {
                IsFire = true;
                if(firingCoroutine != null) StopCoroutine(firingCoroutine);
                firingCoroutine = StartCoroutine(SpawnSphereWithDelay());               
            }
        }

        public void Stop()
        {
            if (IsFire)
            {
                StopCoroutine(SpawnSphereWithDelay());
                PoolManger.RemoveAllSpheres();
                IsFire = false;
            }
        }

        private IEnumerator SpawnSphereWithDelay()
        {
            while (IsFire)
            {
                SpawnSphere();
                yield return new WaitForSeconds(fireRate);
            }
        }
        void SpawnSphere()
        {
            var proyectile = PoolManger.GetSphereProyectile();
            proyectile?.Fire(Target);
        }

    }
}
