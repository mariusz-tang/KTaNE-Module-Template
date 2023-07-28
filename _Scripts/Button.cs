using System;
using UnityEngine;

// * This is a generic animated button component.
// * Setup instructions: (WIP)
[RequireComponent(typeof(KMSelectable), typeof(Animator))]
public class Button : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonDownSound;
    [SerializeField] private AudioClip _buttonUpSound;

    private KMAudio _audio;
    private Animator _animator;
    private KMSelectable _selectable;

    public event Action OnInteract;
    public event Action OnInteractEnded;

    public bool IsActive { get; set; } = true;

    protected void Awake() {
        _audio = GetComponentInParent<KMAudio>();
        _animator = GetComponent<Animator>();
        _selectable = GetComponent<KMSelectable>();

        _selectable.OnInteract += () => {
            _animator.SetBool("IsPressed", true);
            _audio.PlaySoundAtTransform(_buttonDownSound.name, transform);
            if (IsActive)
                OnInteract?.Invoke();
            return false;
        };
        _selectable.OnInteractEnded += () => {
            _animator.SetBool("IsPressed", false);
            _audio.PlaySoundAtTransform(_buttonUpSound.name, transform);
            if (IsActive)
                OnInteractEnded?.Invoke();
        };
    }

    public void Select() => _selectable.OnInteract();
    public void Deselect() => _selectable.OnInteractEnded();
}