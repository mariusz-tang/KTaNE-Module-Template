using UnityEngine; // Monobehaviour

[RequireComponent(typeof(KMBombModule), typeof(KMSelectable))]
public partial class ExampleModule : MonoBehaviour
{
    // This module uses the custom Button component included with the template.
    [SerializeField] private Button _solveButton;
    [SerializeField] private Button _strikeButton;

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
    }

    // Delete the rest of the methods since they are not needed.
#pragma warning restore IDE0051

    public void Log(string message) => Debug.Log($"[Example #{_moduleId}] {message}");

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
