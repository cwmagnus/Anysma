using UnityEngine;
using UnityEngine.UI;

namespace Anysma
{
    /// <summary>
    /// Logs a position to ui text.
    /// </summary>
    public class PositionLogger : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private string label;
        [SerializeField]
        private Text logText;

        /// <summary>
        /// Update the log text.
        /// </summary>
        private void Update()
        {
            logText.text = string.Format("{0} X:{1} Y:{2}",
                label, Mathf.RoundToInt(target.position.x), Mathf.RoundToInt(target.position.y));
        }
    }

}