using UnityEngine;

// ! This is a generic button class. Needs button press and release animations and sounds to work.
[RequireComponent(typeof(KMSelectable), typeof(Animator))]
public class ModuleButton : MonoBehaviour {

    private KMAudio _audio;
    private Animator _animator;

    public KMSelectable Selectable { get; private set; }

    public void Awake() {
        Selectable = GetComponent<KMSelectable>();
        Selectable.OnInteract += () => {
            _animator.SetBool("IsPressed", true);
            _audio.PlaySoundAtTransform("ButtonPress", transform);
            return true;
        };
        Selectable.OnInteractEnded += () => {
            _animator.SetBool("IsPressed", false);
            _audio.PlaySoundAtTransform("ButtonRelease", transform);
        };

        _animator = GetComponent<Animator>();
        _audio = GetComponentInParent<KMAudio>();
    }
}