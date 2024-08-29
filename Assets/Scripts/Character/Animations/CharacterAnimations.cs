using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    Animator _animator;
    PlayerInputs _inputs;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputs = GetComponent<PlayerInputs>();
    }
    private void Update()
    {
        if (_animator != null)
        {
            _animator.SetBool("forward", _inputs.forward);
            _animator.SetBool("backward", _inputs.backward);
            transform.Rotate(0,_inputs.right + _inputs.left,0); 
        }
    }
}
