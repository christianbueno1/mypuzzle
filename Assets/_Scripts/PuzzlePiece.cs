using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClick;
    private bool _dragging, _placed;

    void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        
        // _offset = GetMousePos() - (Vector2)transform.position;
    }
}
