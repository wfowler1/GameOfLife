using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public UIRoot root;
    public Button optionsButton;
    public RectTransform setDimensionsPanel;
    public TMP_InputField xField;
    public TMP_InputField yField;
    public TMP_InputField zField;
    public TMP_InputField wField;

    public RectTransform colorSliderPanel;
    
    public RectTransform rulesPanel;
    public TMP_InputField rulesBirthField;
    public TMP_InputField rulesSurvivalField;
    public RectTransform randomizationPanel;
    public TMP_InputField randomizationField;
    public Toggle wrappingToggle;
    public Toggle debugToggle;
    public Button quitButton;

    private bool showingMenu = false;
    private bool showedWarning = false;

    public void Start()
    {
        if (root == null)
        {
            root = transform.parent.GetComponent<UIRoot>();
        }

        SetMenuState(false);
    }

    public void ToggleMenu()
    {
        SetMenuState(!showingMenu);
    }

    public void SetMenuState(bool show)
    {
        setDimensionsPanel.gameObject.SetActive(show);
        colorSliderPanel.gameObject.SetActive(show);
        rulesPanel.gameObject.SetActive(show);
        randomizationPanel.gameObject.SetActive(show);
        wrappingToggle.gameObject.SetActive(show);
        debugToggle.gameObject.SetActive(show);
        quitButton.gameObject.SetActive(show);

        if (!show)
        {
            SetButtonText(optionsButton, "Options \\/");
        }
        else
        {
            SetButtonText(optionsButton, "Options /\\");
            UpdateValues();
        }

        showingMenu = show;
    }

    public void UpdateValues()
    {
        xField.text = root.gameBehaviour.game.width.ToString();
        yField.text = root.gameBehaviour.game.height.ToString();
        zField.text = root.gameBehaviour.game.depth.ToString();
        wField.text = root.gameBehaviour.game.colors.ToString();
        rulesBirthField.text = GetRulesFieldNumbers(root.gameBehaviour.game.birth);
        rulesSurvivalField.text = GetRulesFieldNumbers(root.gameBehaviour.game.survival);
        randomizationField.text = (root.gameBehaviour.game.initialPercentAlive * 100f).ToString();
        wrappingToggle.isOn = root.gameBehaviour.game.wrap;
        debugToggle.isOn = root.debug;
    }

    private void SetButtonText(Button button, string text)
    {
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }

    public void OnSetDimensionsClicked()
    {
        int width = int.Parse(xField.text);
        int height = int.Parse(yField.text);
        int depth = int.Parse(zField.text);
        int colors = int.Parse(wField.text);
        int newCellsAmt = width * height * depth * colors;
        int newCubes = newCellsAmt - root.gameBehaviour.game.numCells;
        if (!showedWarning && newCellsAmt > 65536)
        {
            root.modal.Show((result) => {
                if (result == 0)
                {
                    SetDimensions(width, height, depth, colors);
                    root.gameBehaviour.Randomize();
                    showedWarning = true;
                }
            },
            "This will create " + newCubes.ToString("###,##0") + " new cells and bring the total to " + newCellsAmt.ToString("###,##0") + ". This may cause poor performance and instability. Continue?",
            "Yes", "No", null);
        }
        else
        {
            SetDimensions(width, height, depth, colors);
            root.gameBehaviour.Randomize();
        }
    }

    private void SetDimensions(int width, int height, int depth, int colors)
    {
        root.gameBehaviour.Resize(width, height, depth, colors);
        root.gameCamera.distance = Mathf.Max(root.gameBehaviour.game.width, root.gameBehaviour.game.height, root.gameBehaviour.game.depth) * 1.6f;
    }

    public void OnColorSliderChanged(Slider sender)
    {
        ColorBlock colors = sender.colors;
        float hue = sender.value;
        Color color = Color.HSVToRGB(hue, 1, 1);
        colors.normalColor = color;
        colors.pressedColor = color;
        colors.highlightedColor = color;
        colors.selectedColor = color;
        sender.colors = colors;

        root.gameBehaviour.Hue = hue;
    }

    public void OnBirthFieldDoneEditing()
    {
        root.gameBehaviour.game.birth = ParseRulesFieldNumbers(rulesBirthField.text);
        root.gameBehaviour.forceFullUpdateNextTick = true;
    }

    public void OnSurvivalFieldDoneEditing()
    {
        root.gameBehaviour.game.survival = ParseRulesFieldNumbers(rulesSurvivalField.text);
        root.gameBehaviour.forceFullUpdateNextTick = true;
    }

    public void OnRandomizationFieldDoneEditing()
    {
        root.gameBehaviour.game.initialPercentAlive = Mathf.Clamp(float.Parse(randomizationField.text) / 100f, 0f, 100f);
        randomizationField.text = (root.gameBehaviour.game.initialPercentAlive * 100f).ToString("##0.###");
    }

    private int[] ParseRulesFieldNumbers(string st)
    {
        string[] substrings = st.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] nums = new int[substrings.Length];
        for (int i = 0; i < substrings.Length; ++i)
        {
            nums[i] = int.Parse(substrings[i]);
        }

        Array.Sort(nums);
        return nums;
    }

    private string GetRulesFieldNumbers(int[] nums)
    {
        return string.Join(' ', nums);
    }

    public void OnWrappingToggleChanged()
    {
        root.gameBehaviour.game.wrap = wrappingToggle.isOn;
        root.gameBehaviour.forceFullUpdateNextTick = true;
    }

    public void OnDebugToggleChanged()
    {
        root.debug = debugToggle.isOn;
    }

    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
