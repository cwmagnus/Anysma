using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Projectile that moves forward.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10f;
        [SerializeField]
        private float damage = 5f;
        [SerializeField]
        private GameObject explosionPrefab;

        private Rigidbody2D body;

        /// <summary>
        /// Get the damage that the projectile does.
        /// </summary>
        public float Damage { get { return damage; } }

        /// <summary>
        /// Move the projectile and destroy after 2 seconds.
        /// </summary>
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            body.AddForce(transform.up * speed);

            Destroy(gameObject, 2f);
        }

        /// <summary>
        /// Check collision with game objects.
        /// </summary>
        /// <param name="other">Object that collided.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Bounds")
            {
                if (transform.tag == "PlayerProjectile")
                {
                    if (other.tag == "Enemy" || other.tag == "Asteroid")
                    {
                        other.GetComponent<Health>().TakeDamage(damage);
                    }
                    if (other.tag != "Player")
                    {
                        Instantiate(explosionPrefab, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }
                }
                else if (transform.tag == "EnemyProjectile")
                {
                    if (other.tag == "Player" || other.tag == "Asteroid")
                    {
                        other.GetComponent<Health>().TakeDamage(damage);
                    }
                    if (other.tag != "Enemy")
                    {
                        Instantiate(explosionPrefab, transform.position, transform.rotation);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}