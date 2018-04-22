using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerMovement: MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        // Time to move
        private float movementTime;

        private Rigidbody2D body;

        /// <summary>
        /// Get body reference.
        /// </summary>
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Moves the rigid body.
        /// </summary>
        public void FixedUpdate()
        {
            if (movementTime > 0)
            {
                float deltaMove = Time.deltaTime * speed;
                body.AddForce(transform.up * deltaMove);
            }
            // Set movement time to 0 if lower than 0
            movementTime = (movementTime < 0) ? 0 : movementTime - Time.deltaTime;
        }

        /// <summary>
        /// Set the movement time.
        /// </summary>
        /// <param name="movementTime">New movement time.</param>
        public void SetMoveTime(int movementTime)
        {
            // Make movement time shorter
            this.movementTime = movementTime / 2.0f;
        }
    }
}