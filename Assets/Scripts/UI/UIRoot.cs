using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
    public Canvas canvas;
    public ModalDialog modal;
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
            string xString = ParseDimension(gameBehaviour.game.dimensions.x);
            string yString = ParseDimension(gameBehaviour.game.dimensions.y);
            string zString = ParseDimension(gameBehaviour.game.dimensions.z);
            string wString = ParseDimension(gameBehaviour.game.dimensions.w);
            sb.Append("Dimensions: ")
            .Append(xString)
            .Append("x")
            .Append(yString)
            .Append("x")
            .Append(zString)
            .Append("x")
            .Append(wString)
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
            .Append(string.Join(',', gameBehaviour.game.survival));

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

    private string ParseDimension(int dim)
    {
        return dim < 0 ? Math.Abs(dim).ToString("###,##0") + "∞" : dim.ToString("###,##0");
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
        gameBehaviour.RecenterCamera();
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
