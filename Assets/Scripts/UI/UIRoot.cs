using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
    public ModalDialog modal;
    public CameraControl gameCamera;
    public GameOfLifeBehaviour gameBehaviour;
    public TextMeshProUGUI rulesText;
    public OptionsMenu optionsMenu;
    public PresetsMenu presetsMenu;
    public Button playButton;
    public Button tickButton;

    public void Start()
    {
        UpdateStates();
    }

    public void Update()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Dimensions: ")
        .Append(gameBehaviour.game.width)
        .Append("x")
        .Append(gameBehaviour.game.height)
        .Append("x")
        .Append(gameBehaviour.game.depth)
        .Append("x")
        .Append(gameBehaviour.game.colors)
        .Append("\nRules:\n B")
        .Append(string.Join(',', gameBehaviour.game.birth))
        .Append("\n S")
        .Append(string.Join(',', gameBehaviour.game.survival))
        .Append("\nWrapping: ")
        .Append(gameBehaviour.game.wrap ? "Yes" : "No")
        .Append("\nAlive: ")
        .Append(gameBehaviour.game.numAlive)
        .Append("\nGeneration: ")
        .Append(gameBehaviour.game.tickNum)
        .Append("\nBehavior: ")
        .Append(gameBehaviour.game.currentBehavior);
        rulesText.text = sb.ToString();
    }

    public void UpdateStates()
    {
        tickButton.interactable = gameBehaviour.paused;
        modal.gameObject.SetActive(false);

        if (gameBehaviour.paused)
        {
            SetButtonText(playButton, "Play");
        }
        else
        {
            SetButtonText(playButton, "Pause");
        }
    }

    public void OnPlayPauseClicked()
    {
        gameBehaviour.paused = !gameBehaviour.paused;
        UpdateStates();
    }

    public void OnChangeSpeedClicked(float amt)
    {
        gameBehaviour.tickTime += amt;
        if (gameBehaviour.tickTime < 0)
        {
            gameBehaviour.tickTime = 0;
        }
    }

    public void OnRecenterCameraClicked()
    {
        gameCamera.target = Vector3.zero;
        gameCamera.pitch = 0;
        gameCamera.yaw = 0;
        gameCamera.distance = Mathf.Max(gameBehaviour.game.width, gameBehaviour.game.height, gameBehaviour.game.depth) * 1.6f;
    }

    public void OnStepClicked()
    {
        gameBehaviour.Tick();
    }

    public void OnRandomizeClicked()
    {
        gameBehaviour.Randomize();
    }
    
    private void SetButtonText(Button button, string text)
    {
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }
}
