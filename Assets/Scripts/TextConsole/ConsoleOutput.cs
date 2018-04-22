using UnityEngine;
using UnityEngine.UI;

namespace Anysma
{
    /// <summary>
    /// Outputs text to a virtual console.
    /// </summary>
    public class ConsoleOutput : MonoBehaviour
    {
        [SerializeField]
        private Text[] consoleOutputLines;

        /// <summary>
        /// Print out text to the virtual console.
        /// </summary>
        /// <param name="text">Text to print.</param>
        public void Print(string text)
        {
            for (int i = 1; i < consoleOutputLines.Length; i++)
            {
                consoleOutputLines[i - 1].text = consoleOutputLines[i].text;
            }
            consoleOutputLines[consoleOutputLines.Length - 1].text = text;
        }
    }
}
