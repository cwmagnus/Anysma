using UnityEngine;
using UnityEngine.UI;

namespace Anysma
{
    /// <summary>
    /// Displays health to a health bar.
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private Slider healthBar;

        /// <summary>
        /// Update the health bar.
        /// </summary>
        private void Update()
        {
            healthBar.value = health.HealthPercent();
        }
    }
}