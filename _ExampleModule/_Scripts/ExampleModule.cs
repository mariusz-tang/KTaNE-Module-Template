using UnityEngine; // Monobehaviour

// This is a very simple module with a solve button and a strike button.
// Additionally, it displays its display name and module id, which can be helpful for testing other modules which depend on other modules being present on the bomb!
[RequireComponent(typeof(KMBombModule), typeof(KMSelectable))]
public partial class ExampleModule : MonoBehaviour
{
    // This module uses the custom Button component included with the template.
    [SerializeField] private Button _solveButton;
    [SerializeField] private Button _strikeButton;

    [SerializeField] private TextMesh[] _displayNameText;
    [SerializeField] private TextMesh[] _moduleIdText;

    private KMBombModule _module;

    private static int s_moduleCount;
    private int _moduleId;

#pragma warning disable IDE0051
    private void Awake() {
        _moduleId = s_moduleCount++;
        _module = GetComponent<KMBombModule>();

        // Assign interaction handlers.
        _solveButton.OnInteract += Solve;
        _strikeButton.OnInteract += () => { Strike("You pressed the strike button!"); };

        for (int i = 0; i < 2; i++) {
            _displayNameText[i].text = _module.ModuleDisplayName;
            _moduleIdText[i].text = _module.ModuleType;
        }
    }

    // Delete the rest of the methods since they are not needed.
#pragma warning restore IDE0051

    public void Log(string message) => Debug.Log($"[{_module.ModuleDisplayName} #{_moduleId}] {message}");

    public void Strike(string message) {
        Log($"✕ {message}");
        _module.HandleStrike();
    }

    public void Solve() {
        Log("◯ Module solved!");
        _module.HandlePass();

        // Disable the buttons. This does not disable their animations.
        _solveButton.IsActive = false;
        _strikeButton.IsActive = false;
    }
}
