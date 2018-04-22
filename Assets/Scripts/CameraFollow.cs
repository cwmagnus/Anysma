using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Makes the camera follow a target smoothly.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float smoothSpeed = 0.125f;
        [SerializeField]
        private Vector3 offset;

        private Vector3 currentVelocity = Vector3.zero;

        /// <summary>
        /// Follows the target.
        /// </summary>
        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}