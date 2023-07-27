using System.Collections;
// using System.Text.RegularExpressions;

#pragma warning disable IDE1006
// ! This name must match the name in the main class file.
partial class ModuleModule
{
    // * TP Documentation: https://github.com/samfundev/KtaneTwitchPlays/wiki/External-Mod-Module-Support
    // ! Remove if not used. For more niche things like TwitchManualCode and ZenModeActive, look at tp docs ^^
    // private bool TwitchPlaysActive;
    // private bool TwitchShouldCancelCommand;
#pragma warning disable 414, IDE0051
    private readonly string TwitchHelpMessage = @"Use '!{0} breh' to do things | '!{0} breh2' to do other things; extra information here.";
#pragma warning restore 414, IDE1006

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
        Log("TP autosolver has not yet been implemented. Calling KMBombModule.HandlePass.");
        _module.HandlePass();
        yield return null;
    }
#pragma warning restore IDE0051
// * Declare any TP helper methods here.
}