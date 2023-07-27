using System;
using UnityEngine;

// * This is a generic animated button component.
// * Setup instructions: (WIP)
[RequireComponent(typeof(KMSelectable), typeof(Animator))]
public class Button : MonoBehaviour
{
    private KMAudio _audio;
    private Animator _animator;
    private KMSelectable _selectable;

    public event Action OnInteract;
    public event Action OnInteractEnded;

    public bool IsActive { get; set; }

    public void Awake() {
        _audio = GetComponentInParent<KMAudio>();
        _animator = GetComponent<Animator>();
        _selectable = GetComponent<KMSelectable>();

        _selectable.OnInteract += () => {
            _animator.SetBool("IsPressed", true);
            _audio.PlaySoundAtTransform("ButtonPress", transform);
            if (IsActive)
                OnInteract?.Invoke();
            return false;
        };
        _selectable.OnInteractEnded += () => {
            _animator.SetBool("IsPressed", false);
            _audio.PlaySoundAtTransform("ButtonRelease", transform);
            if (IsActive)
                OnInteractEnded?.Invoke();
        };
    }
}