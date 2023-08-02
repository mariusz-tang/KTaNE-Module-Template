using System;
using UnityEngine;

// * This is a generic animated button component.
// * Setup instructions: (WIP)
[RequireComponent(typeof(KMSelectable))]
public class Button : MonoBehaviour
{
    [SerializeField] private ButtonInfo _buttonTypeInfo;

    private KMAudio _audio;
    private Animator _animator;
    private KMSelectable _selectable;

    public event Action OnInteract;
    public event Action OnInteractEnded;

    public bool IsActive { get; set; } = true;

    protected void Awake() {
        _audio = GetComponentInParent<KMAudio>();
        _animator = gameObject.AddComponent<Animator>();
        _selectable = GetComponent<KMSelectable>();

        _animator.runtimeAnimatorController = _buttonTypeInfo.AnimatorController;
        _selectable.OnInteract += () => {
            _animator.SetBool("IsPressed", true);
            _audio.PlaySoundAtTransform(_buttonTypeInfo.ButtonDownSound, transform);
            if (IsActive)
                OnInteract?.Invoke();
            return false;
        };
        _selectable.OnInteractEnded += () => {
            _animator.SetBool("IsPressed", false);
            _audio.PlaySoundAtTransform(_buttonTypeInfo.ButtonUpSound, transform);
            if (IsActive)
                OnInteractEnded?.Invoke();
        };
    }

    public void Select() => _selectable.OnInteract();
    public void Deselect() => _selectable.OnInteractEnded();
}