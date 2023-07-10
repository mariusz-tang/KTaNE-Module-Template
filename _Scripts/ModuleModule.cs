using System.Collections;
// using System.Text.RegularExpressions; // Useful for implementing TP.
// using KModkit; // You must import this namespace to KMBombInfoExtensions, among other things.
using UnityEngine;
// ! Remember to remove unnecessary using directives once the module is finished.

// ! Remember that the class and file names have to match.
public class ModuleModule : MonoBehaviour {

    // ! Remove KMBombInfo and KMAudio if not used.
    private KMBombInfo _bombinfo;
    private KMAudio _audio;
    private KMBombModule _module;

    // ! _isSolved should be kept even if not needed, to help with future souvenir implementation.
    private static int _moduleCount;
    private int _moduleId;
    private bool _isSolved;

    private void Awake() {
        _moduleId = _moduleCount++;

        _bombinfo = GetComponent<KMBombInfo>();
        _audio = GetComponent<KMAudio>();
        _module = GetComponent<KMBombModule>();

        // ! Remove if not used.
        _module.OnActivate += Activate;
        _bombinfo.OnBombExploded += OnBombExploded;
        _bombinfo.OnBombSolved += OnBombSolved;

        // ! Declare other references here if needed.
    }

    // ! Things like querying edgework need to be done after Awake is called, eg. subscribing to ModuleButton.Selectable.OnInteract.
    private void Start() { }

    // ! This is called once the lights turn on.
    private void Activate() { }

    // ! I don't typically use Update in the main script.
    private void Update() { }

    // ! Sometimes, it helps to run code (eg. to stop looping sounds) when the module is no longer active
    // ! (bomb explodes, quit to office, etc.).
    private void OnDestroy() { }

    // ! Some modules do things here, like Phosphorescence's Bejeweled announcer voiceline.
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
