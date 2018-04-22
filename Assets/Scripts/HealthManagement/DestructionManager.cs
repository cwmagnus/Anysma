using UnityEngine.SceneManagement;
using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Handles destroying game objects with no health left.
    /// </summary>
    public class DestructionManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject explosionPrefab;
        [SerializeField]

        private Health health;

        /// <summary>
        /// Get health component.
        /// </summary>
        private void Start()
        {
            health = GetComponent<Health>();
        }

        /// <summary>
        /// Destroy if out of health.
        /// </summary>
        private void Update()
        {
            if (health.OutOfHealth())
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                if (transform.tag == "Player")
                {
                    SceneManager.LoadScene("Lose");
                }
                Destroy(gameObject);
            }
        }
    }
}