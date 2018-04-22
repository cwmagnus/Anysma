using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Rotates a physics body randomly.
    /// </summary>
    public class RotatingBody : MonoBehaviour
    {
        [SerializeField]
        private Vector2 angularVelocityRange;

        private Rigidbody2D body;

        /// <summary>
        /// Rotate the body.
        /// </summary>
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            body.angularVelocity = Random.Range(angularVelocityRange.x, angularVelocityRange.y);
        }
    }
}