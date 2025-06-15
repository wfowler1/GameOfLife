using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PresetsMenu : MonoBehaviour
{
    public UIRoot root;
    public Button presetsButton;
    public Button new2DButton;
    public Button new3DButton;
    public Button new4DButton;
    public Button presets2DButton;
    public Button presets3DButton;
    public Button presets4DButton;
    public Button demos2DButton;
    public Button demos3DButton;
    public RectTransform presets2DMenu;
    public RectTransform presets3DMenu;
    public RectTransform presets4DMenu;
    public RectTransform demos2DMenu;
    public RectTransform demos3DMenu;

    private bool showingMenu = false;

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
        presets2DButton.gameObject.SetActive(show);
        presets3DButton.gameObject.SetActive(show);
        presets4DButton.gameObject.SetActive(show);
        new2DButton.gameObject.SetActive(show);
        new3DButton.gameObject.SetActive(show);
        new4DButton.gameObject.SetActive(show);
        demos2DButton.gameObject.SetActive(show);
        demos3DButton.gameObject.SetActive(show);

        if (!show)
        {
            HideAllSubmenus();
            SetButtonText(presetsButton, "Presets \\/");
        }
        else
        {
            SetButtonText(presetsButton, "Presets /\\");
        }

        showingMenu = show;
    }

    public void HideAllSubmenus()
    {
        presets2DMenu.gameObject.SetActive(false);
        presets3DMenu.gameObject.SetActive(false);
        presets4DMenu.gameObject.SetActive(false);
        demos2DMenu.gameObject.SetActive(false);
        demos3DMenu.gameObject.SetActive(false);
        SetButtonText(presets2DButton, "< 2D Rules");
        SetButtonText(presets3DButton, "< 3D Rules");
        SetButtonText(presets4DButton, "< 4D Rules");
        SetButtonText(demos2DButton, "< 2D Demos");
        SetButtonText(demos3DButton, "< 3D Demos");
        SetButtonColors(presets2DButton, Color.white);
        SetButtonColors(presets3DButton, Color.white);
        SetButtonColors(presets4DButton, Color.white);
        SetButtonColors(demos2DButton, Color.white);
        SetButtonColors(demos3DButton, Color.white);
    }

    public void ToggleSubmenu(Button sender)
    {
        string buttonText = sender.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(2);
        RectTransform submenu = null;
        if (sender == presets2DButton)
        {
            submenu = presets2DMenu;
        }
        else if (sender == presets3DButton)
        {
            submenu = presets3DMenu;
        }
        else if (sender == presets4DButton)
        {
            submenu = presets4DMenu;
        }
        else if (sender == demos2DButton)
        {
            submenu = demos2DMenu;
        }
        else if (sender == demos3DButton)
        {
            submenu = demos3DMenu;
        }

        bool wasActive = submenu.gameObject.activeSelf;
        HideAllSubmenus();
        submenu.gameObject.SetActive(!wasActive);
        SetButtonText(sender, (wasActive ? "< " : "> ") + buttonText);
        SetButtonColors(sender, wasActive ? Color.white : Color.green);
    }

    private void SetButtonText(Button button, string text)
    {
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void SetButtonColors(Button button, Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        colors.highlightedColor = color;
        colors.pressedColor = new Color(color.r / 0.8f, color.g / 0.8f, color.b / 0.8f);
        colors.selectedColor = color;
        button.colors = colors;
    }

    private void HideMenuAndDoUpdates()
    {
        SetMenuState(false);
        root.optionsMenu.UpdateValues();
        root.gameBehaviour.forceFullUpdateNextTick = true;
    }

    public void OnNew2DClicked()
    {
        root.gameBehaviour.Resize(64, 64, 1, 1);
        root.gameBehaviour.Randomize();
    }

    public void OnNew3DClicked()
    {
        root.gameBehaviour.Resize(32, 32, 32, 1);
        root.gameBehaviour.Randomize();
    }

    public void OnNew4DClicked()
    {
        root.gameBehaviour.Resize(12, 12, 12, 12);
        root.gameBehaviour.Randomize();
    }

    public void OnLifeClicked()
    {
        root.gameBehaviour.game.ConwayRules();
        HideMenuAndDoUpdates();
    }

    public void On34LifeClicked()
    {
        root.gameBehaviour.game.ThreeFourRules();
        HideMenuAndDoUpdates();
    }

    public void OnSeedsClicked()
    {
        root.gameBehaviour.game.SeedsRules();
        HideMenuAndDoUpdates();
    }

    public void OnLifeWithoutDeathClicked()
    {
        root.gameBehaviour.game.LifeWithoutDeathRules();
        HideMenuAndDoUpdates();
    }

    public void OnHighLifeClicked()
    {
        root.gameBehaviour.game.HighLifeRules();
        HideMenuAndDoUpdates();
    }

    public void OnAssimilationClicked()
    {
        root.gameBehaviour.game.AssimilationRules();
        HideMenuAndDoUpdates();
    }

    public void OnFredkinClicked()
    {
        root.gameBehaviour.game.FredkinRules();
        HideMenuAndDoUpdates();
    }

    public void OnAnnealClicked()
    {
        root.gameBehaviour.game.AnnealRules();
        HideMenuAndDoUpdates();
    }

    public void OnMorleyClicked()
    {
        root.gameBehaviour.game.MorleyRules();
        HideMenuAndDoUpdates();
    }

    public void OnRiversClicked()
    {
        root.gameBehaviour.game.RiversRules();
        HideMenuAndDoUpdates();
    }

    public void OnCitiesClicked()
    {
        root.gameBehaviour.game.CitiesRules();
        HideMenuAndDoUpdates();
    }

    public void OnBays5766Clicked()
    {
        root.gameBehaviour.game.Bays5766Rules();
        HideMenuAndDoUpdates();
    }

    public void OnBays4555Clicked()
    {
        root.gameBehaviour.game.Bays4555Rules();
        HideMenuAndDoUpdates();
    }

    public void OnBays10211021Clicked()
    {
        root.gameBehaviour.game.Bays10211021Rules();
        HideMenuAndDoUpdates();
    }

    public void OnB5S47Clicked()
    {
        root.gameBehaviour.game.BaysB5S47Rules();
        HideMenuAndDoUpdates();
    }

    public void OnB78S5678Clicked()
    {
        root.gameBehaviour.game.B78S5678Rules();
        HideMenuAndDoUpdates();
    }

    public void OnWallaceClicked()
    {
        root.gameBehaviour.game.Wallace1Rules();
        HideMenuAndDoUpdates();
    }

    public void OnWallace2Clicked()
    {
        root.gameBehaviour.game.Wallace2Rules();
        HideMenuAndDoUpdates();
    }

    public void OnEvansClicked()
    {
        root.gameBehaviour.game.EvansRules();
        HideMenuAndDoUpdates();
    }

    public void OnLifeWithoutDeath3DClicked()
    {
        root.gameBehaviour.game.LifeWithoutDeath3DRules();
        HideMenuAndDoUpdates();
    }

    public void OnFredkin3DClicked()
    {
        root.gameBehaviour.game.Fredkin3DRules();
        HideMenuAndDoUpdates();
    }

    public void OnB2123S10224DClicked()
    {
        root.gameBehaviour.game.B2123S10224DRules();
        HideMenuAndDoUpdates();
    }

    public void OnB4163S40804DClicked()
    {
        root.gameBehaviour.game.B4163S40804DRules();
        HideMenuAndDoUpdates();
    }

    public void OnSimpleGliderClicked()
    {
        root.gameBehaviour.game.SimpleGlider();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 20 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnSpaceShipsClicked()
    {
        root.gameBehaviour.game.SpaceShips();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 20 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnPulsarClicked()
    {
        root.gameBehaviour.game.Pulsar();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 17 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnPentaDecathlonClicked()
    {
        root.gameBehaviour.game.PentaDecathlon();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 18 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnGosperGunClicked()
    {
        root.gameBehaviour.game.GosperGun();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 23 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnAcornClicked()
    {
        root.gameBehaviour.game.Acorn();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 214;
        HideMenuAndDoUpdates();
    }

    public void OnFredkin64Clicked()
    {
        root.gameBehaviour.game.Fredkin64();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 128;
        HideMenuAndDoUpdates();
    }

    public void OnSimpleGlider3DClicked()
    {
        root.gameBehaviour.game.SimpleGlider3D();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 32 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void On4555GliderClicked()
    {
        root.gameBehaviour.game.Glider4555();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 32 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnB5S47GliderClicked()
    {
        root.gameBehaviour.game.GliderB5S47();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 32 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnEvansGliderClicked()
    {
        root.gameBehaviour.game.EvansGlider();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 16 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnBays5766InfiniGliderClicked()
    {
        root.gameBehaviour.game.Bays5766InfiniGlider();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 16 * 1.6f;
        HideMenuAndDoUpdates();
    }

    public void OnAcorn3DClicked()
    {
        root.gameBehaviour.game.Acorn3D();
        root.gameBehaviour.RefreshAll();
        root.gameCamera.distance = 214;
        HideMenuAndDoUpdates();
    }
}
