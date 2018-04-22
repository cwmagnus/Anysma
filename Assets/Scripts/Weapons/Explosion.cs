using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Handles explosions.
    /// </summary>
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private float explosionTime = 2f;

        /// <summary>
        /// Destory the explosion.
        /// </summary>
        private void Start()
        {
            Destroy(gameObject, explosionTime);
        }
    }
}