using Meta.WitAi.TTS.Utilities;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private TMP_Text inputField;
        [SerializeField] private TMP_Text textArea;
        [SerializeField] private TTSSpeaker speaker;
        public InputActionReference input;


        [SerializeField] private Image image;
        [SerializeField] private GameObject loadingLabel;

        private OpenAIApi openai = new OpenAIApi("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");

        private string userInput;
        private string Instruction = "Act as a random stranger in a chat room and reply to the questions.\nQ: ";

        private void Awake()
        {
            input.action.started += SendReplyFromMic;
        }

        private void OnDestroy()
        {
            input.action.started -= SendReplyFromMic;
        }


        public void SendReplyFromMic(InputAction.CallbackContext context)
        {
            SendReply();
        }

        public void SendReplyFromMic()
        {
            SendReply();
        }

        private async void SendReply()
        {
            userInput = inputField.text;
            Instruction += $"{userInput}\nA: ";

            textArea.text = "...";
            inputField.text = "";

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
                speaker.Speak(completionResponse.Choices[0].Text);
                textArea.text = completionResponse.Choices[0].Text;
                if (textArea.text != null)
                {
                    TriggerGPTImageRequest(textArea.text);
                }
                Instruction += $"{completionResponse.Choices[0].Text}\nQ: ";
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            inputField.enabled = true;
        }

        private async void TriggerGPTImageRequest(string gptResponse)
        {
            image.sprite = null;
            loadingLabel.SetActive(true);

            var response = await openai.CreateImage(new CreateImageRequest
            {
                Prompt = gptResponse,
                Size = ImageSize.Size256
            });

            if (response.Data != null && response.Data.Count > 0)
            {
                using (var request = new UnityWebRequest(response.Data[0].Url))
                {
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(request.downloadHandler.data);
                    var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                    image.sprite = sprite;
                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }

            inputField.enabled = true;
            loadingLabel.SetActive(false);
        }
    }
}