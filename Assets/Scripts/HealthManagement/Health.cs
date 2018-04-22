using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Keeps track of health related stuff.
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float health;

        private float originalHealth;

        /// <summary>
        /// Set the original health.
        /// </summary>
        private void Start()
        {
            originalHealth = health;
        }

        /// <summary>
        /// Take damage on health.
        /// </summary>
        /// <param name="damage">Damage to take.</param>
        public void TakeDamage(float damage)
        {
            health -= damage;
        }

        /// <summary>
        /// Check if out of health.
        /// </summary>
        /// <returns>Out of health flag.</returns>
        public bool OutOfHealth()
        {
            return health <= 0;
        }

        /// <summary>
        /// Get the percent of health left in decimal form.
        /// </summary>
        /// <returns>Percent of health in decimal form.</returns>
        public float HealthPercent()
        {
            return health / originalHealth;
        }
    }
}