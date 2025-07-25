using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
    public Canvas canvas;
    public ModalDialog modal;
    public CameraControl gameCamera;
    public GameOfLifeBehaviour gameBehaviour;
    public TextMeshProUGUI rulesText;
    public OptionsMenu optionsMenu;
    public PresetsMenu presetsMenu;
    public Button playButton;
    public Button tickButton;

    public bool debug = false;

    public void Start()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }

        UpdateStates();
    }

    public void Update()
    {
        gameBehaviour.debug = debug;

        if (canvas.enabled)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dimensions: ")
            .Append(gameBehaviour.game.width.ToString("###,##0"))
            .Append("x")
            .Append(gameBehaviour.game.height.ToString("###,##0"))
            .Append("x")
            .Append(gameBehaviour.game.depth.ToString("###,##0"))
            .Append("x")
            .Append(gameBehaviour.game.colors.ToString("###,##0"))
            .Append("\nCells in world: ")
            .Append(gameBehaviour.game.numCells.ToString("###,##0"))
            .Append("\nAlive: ")
            .Append(gameBehaviour.game.numAlive.ToString("###,##0"))
            .Append(" (")
            .Append(gameBehaviour.game.numCells > 0 ? (gameBehaviour.game.numAlive * 100.0f / gameBehaviour.game.numCells).ToString("##0.00") : "0.00")
            .Append("%)\nGeneration: ")
            .Append(gameBehaviour.game.tickNum.ToString("###,##0"))
            .Append("\nRules:\n B")
            .Append(string.Join(',', gameBehaviour.game.birth))
            .Append("\n S")
            .Append(string.Join(',', gameBehaviour.game.survival))
            .Append("\n Wrapping: ")
            .Append(gameBehaviour.game.wrap ? "Yes" : "No");

            if (debug)
            {
                int cubesInMemory = (gameBehaviour.cellPool.Count + gameBehaviour.numCubesInScene);
                sb.Append("\nMemory usage:\n Cubes in Memory: ")
               .Append(cubesInMemory.ToString("###,##0"))
               .Append(" (")
               .Append(gameBehaviour.game.numCells > 0 ? (cubesInMemory * 100.0f / gameBehaviour.game.numCells).ToString("##0.00") : "0.00")
               .Append("% of World)\n Cubes in Scene: ")
               .Append(gameBehaviour.numCubesInScene.ToString("###,##0"))
               .Append(" (")
               .Append(cubesInMemory > 0 ? (gameBehaviour.numCubesInScene * 100.0f / cubesInMemory).ToString("##0.00") : "0.00")
               .Append("%)\n Cubes Pooled: ")
               .Append(gameBehaviour.cellPool.Count.ToString("###,##0"))
               .Append(" (")
               .Append(cubesInMemory > 0 ? (gameBehaviour.cellPool.Count * 100.0f / cubesInMemory).ToString("##0.00") : "0.00")
               .Append("%)\nTimers:\n Tick time: ")
               .Append(gameBehaviour.debugTickTime.ToString("##0.00000"))
               .Append("s\n Scene update time: ")
               .Append(gameBehaviour.debugRefreshTime.ToString("##0.00000"))
               .Append("s");
            }

            rulesText.text = sb.ToString();
        }

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Z))
        {
            canvas.enabled = !canvas.enabled;
        }
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
        gameCamera.distance = Mathf.Max(gameBehaviour.game.width, gameBehaviour.game.height, gameBehaviour.game.depth) * 1.2f;
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
