using System.Collections; // IEnumerator
using UnityEngine; // WaitForSeconds

#pragma warning disable 414, IDE0051, IDE1006
// ! This name must match the name in the main class file.
partial class ExampleModule
{
    private readonly string TwitchHelpMessage = @"Use '!{0} solve' to press ""Solve!"" | '!{0} strike' to press ""Strike!"".";
#pragma warning restore 414, IDE1006

    private IEnumerator ProcessTwitchCommand(string command) {
        command = command.Trim().ToUpperInvariant();

        if (command == "SOLVE") {
            yield return null;
            yield return Press(_solveButton);
        }
        else if (command == "STRIKE") {
            yield return null;
            yield return Press(_strikeButton);
        }
        else
            yield return "sendtochaterror Invalid command!";
    }

    private IEnumerator TwitchHandleForcedSolve() {
        yield return Press(_solveButton);
    }
#pragma warning restore IDE0051

    private IEnumerator Press(Button button) {
        button.Select();
        yield return new WaitForSeconds(.1f);
        button.Deselect();
    }
}