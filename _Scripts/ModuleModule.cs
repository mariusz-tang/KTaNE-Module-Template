// using KModkit; // You must import this namespace to use KMBombInfoExtensions, among other things. See KModKit Docs below.
using UnityEngine;

// ! Remember to remove things that you do not use, including using directives and empty methods.

// * Template Wiki: https://github.com/TheKuroEver/KTaNE-Module-Template/wiki
// * KModKit Documentation: https://github.com/Qkrisi/ktanemodkit/wiki
// ! Remember that the class and file names have to match.
[RequireComponent(typeof(KMBombModule), typeof(KMSelectable))]
public partial class ModuleModule : MonoBehaviour
{
    // private KMBombInfo _bombInfo; // for accessing edgework, and certain events like OnBombExploded.
    // private KMAudio _audio; // for interacting with the game's audio system.
    private KMBombModule _module;

    private static int s_moduleCount;
    private int _moduleId;

#pragma warning disable IDE0051
    // * Called before anything else.
    private void Awake() {
        _moduleId = s_moduleCount++;

        _module = GetComponent<KMBombModule>();
        // _bombInfo = GetComponent<KMBombInfo>(); // (*)
        // _audio = GetComponent<KMAudio>();

        _module.OnActivate += Activate;
        // _bombInfo.OnBombExploded += OnBombExploded; // (**). Requires (*)
        // _bombInfo.OnBombSolved += OnBombSolved; // (***). Requires (*)

        // * Declare other references here if needed.
    }

    // * Called after Awake has been called on all components in the scene, but before anything else.
    // ! Things like querying edgework need to be done after Awake is called, eg. subscribing to OnInteract events.
    private void Start() { }

    // * Called once the lights turn on.
    private void Activate() { }

    // * Update is called every frame. I don't typically use Update in the main script.
    // ! Do not perform resource-intensive tasks here as they will be called every frame and can slow the game down.
    private void Update() { }

    // * Called when the module is removed from the game world.
    // * Examples of when this happens include when the bomb explodes, or if the player quits to the office.
    private void OnDestroy() { }
#pragma warning restore IDE0051

    // private void OnBombExploded() { } // Requires (*) and (**)
    // private void OnBombSolved() { } // Requires (*) and (***)

    public void Log(string message) => Debug.Log($"[{_module.ModuleDisplayName} #{_moduleId}] {message}");

    public void Strike(string message) {
        Log($"✕ {message}");
        _module.HandleStrike();
        // * Add code that should execute on every strike (eg. a strike animation) here.
    }

    public void Solve() {
        Log("◯ Module solved!");
        _module.HandlePass();
        // * Add code that should execute on solve (eg. a solve animation) here.
    }
}
