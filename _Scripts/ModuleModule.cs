using System.Collections;
// using System.Text.RegularExpressions; // Useful for implementing TP.
// using KModkit; // You must import this namespace to use KMBombInfoExtensions, among other things. See KModKit Docs below.
using UnityEngine;
// ! Remember to remove unnecessary using directives once the module is finished.

// * Template Wiki: https://github.com/TheKuroEver/KTaNE-Module-Template/wiki
// * KModKit Documentation: https://github.com/Qkrisi/ktanemodkit/wiki
// ! Remember that the class and file names have to match.
public class ModuleModule : MonoBehaviour {

    // ! Remove KMBombInfo and KMAudio if not used.
    private KMBombInfo _bombInfo;
    private KMAudio _audio;
    private KMBombModule _module;

    // * _isSolved should be kept even if not needed, to help with future souvenir implementation.
    private static int s_moduleCount;
    private int _moduleId;
    private bool _isSolved;

    // * Awake is called before anything else.
    private void Awake() {
        _moduleId = s_moduleCount++;

        _bombInfo = GetComponent<KMBombInfo>();
        _audio = GetComponent<KMAudio>();
        _module = GetComponent<KMBombModule>();

        // ! Remove if not used.
        _module.OnActivate += Activate;
        _bombInfo.OnBombExploded += OnBombExploded;
        _bombInfo.OnBombSolved += OnBombSolved;

        // ! Declare other references here if needed.
    }

    // * Start is called after Awake has been called on all components in the scene, but before anything else.
    // ! Things like querying edgework need to be done after Awake is called, eg. subscribing to ModuleButton.Selectable.OnInteract.
    private void Start() { }

    // * KMBombModule.OnActivate is called once the lights turn on.
    private void Activate() { }

    // * Update is called every frame. I don't typically use Update in the main script.
    // ! Do not do resource-intensive tasks here, they will be called every frame and can slow the game down.
    private void Update() { }

    // * OnDestroy is called when the module is 'destroyed'.
    // * Examples of when this happens include when the bomb explodes, and if the player quits to the office.
    // * Sometimes, it helps to run code at these times, for example to stop looping sounds.
    private void OnDestroy() { }

    // * These are quite self-explanatory.
    private void OnBombExploded() { }
    private void OnBombSolved() { }

    public void Log(string message) {
        Debug.Log($"[Module #{_moduleId}] {message}");
        throw new System.NotImplementedException("Change the logging tag to match the module name.");
    }

    public void Strike(string message) {
        Log($"✕ {message}");
        _module.HandleStrike();
        // ! Add code that should execute on every strike (eg. a strike animation) here.
    }

    public void Solve() {
        Log("◯ Module solved.");
        _module.HandlePass();
        _isSolved = true;
        // ! Add code that should execute on solve (eg. a solve animation) here.
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use '!{0} breh' to do things | '!{0} breh2' to do other things; extra information here.";
#pragma warning restore 414

    // * TP Documentation: https://github.com/samfundev/KtaneTwitchPlays/wiki/External-Mod-Module-Support
    // ! Remove if not used. For more niche things like TwitchManualCode and ZenModeActive, look at tp docs ^^
    private bool TwitchPlaysActive;
    private bool TwitchShouldCancelCommand;

    private IEnumerator ProcessTwitchCommand(string command) {
        yield return "sendtochaterror TP has not yet been implemented.";

        // * Setup for implementing TP using regular expressions for command validation.
        // ! Requires importing the System.Text.RegularExpressions namespace.
        //  command = command.Trim().ToUpperInvariant();

        // Match match = Regex.Match(command, @"EXPRESSION", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
        // if (match.Success) {
        //     yield return null;
        //     //! Do stuff.
        //     yield break;
        // }

        // yield return "sendtochaterror Invalid command!";
    }

    private IEnumerator TwitchHandleForcedSolve() {
        Debug.Log("TP autosolver has not yet been implemented. Calling KMBombModule.HandlePass.");
        _module.HandlePass();
        yield return null;
    }
}
