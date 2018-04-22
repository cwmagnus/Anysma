using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Weapon system that fires projectiles.
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;
        [SerializeField]
        private Transform[] weaponSlots;

        /// <summary>
        /// Fire projectiles.
        /// </summary>
        public void Fire()
        {
            foreach (Transform weaponSlot in weaponSlots)
            {
                var projectile = Instantiate(projectilePrefab,
                    weaponSlot.position, weaponSlot.rotation);
            }
        }
    }
}
