using UnityEngine;
using UnityEngine.UI;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private Text textArea;

        private OpenAIApi openai = new OpenAIApi("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");

        private string userInput;
        private string Instruction = "Act as a random stranger in a chat room and reply to the questions.\nQ: ";

        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }

        private async void SendReply()
        {
            userInput = inputField.text;
            Instruction += $"{userInput}\nA: ";
            
            textArea.text = "...";
            inputField.text = "";

            button.enabled = false;
            inputField.enabled = false;
            
            // Complete the instruction
            var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
            {
                Prompt = Instruction,
                Model = "text-davinci-003",
                MaxTokens = 128
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                textArea.text = completionResponse.Choices[0].Text;
                Instruction += $"{completionResponse.Choices[0].Text}\nQ: ";
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
        }
    }
}
