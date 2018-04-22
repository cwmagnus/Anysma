using UnityEngine;
using UnityEngine.UI;

namespace Anysma
{
    /// <summary>
    /// Gets input from the virtual console.
    /// </summary>
    public class ConsoleInput : MonoBehaviour
    {
        [SerializeField]
        private InputField consoleInput;

        /// <summary>
        /// Set up sumit events and get focus on input field.
        /// </summary>
        private void Start()
        {
            consoleInput.ActivateInputField();

            // Set up the submit event
            var submitEvent = new InputField.SubmitEvent();
            submitEvent.AddListener(Submit);
            consoleInput.onEndEdit = submitEvent;
        }

        /// <summary>
        /// Submit data to the console for processing.
        /// </summary>
        /// <param name="inputText">Text input from console.</param>
        private void Submit(string inputText)
        {
            if (inputText.Length > 0)
            {
                CommandProcessor processor = GetComponent<CommandProcessor>();
                processor.Process(inputText.Split(' '));
            }
            
            // Clear console input
            consoleInput.text = "";
            consoleInput.ActivateInputField();
            consoleInput.Select();
        }
    }
}