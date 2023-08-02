using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ButtonInfoScriptableObject", order = 1)]
public class ButtonInfo : ScriptableObject
{
    [SerializeField] private AudioClip _buttonDownSound;
    [SerializeField] private AudioClip _buttonUpSound;
    [SerializeField] private RuntimeAnimatorController _animatorController;

    public string ButtonDownSound => _buttonDownSound.name;
    public string ButtonUpSound => _buttonUpSound.name;
    public RuntimeAnimatorController AnimatorController => _animatorController;
}
