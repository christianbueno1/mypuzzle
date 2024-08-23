using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;

    [SerializeField] private Transform _slotParent, _pieceParent;

    private int _piecesPlaced;

    void Start()
    {
        Spawn();
    }
    
    void Spawn()
    {
        // var randomSet = _slotPrefabs.OrderBy(s=>Random.value).Take(3).ToList();
        for (int i = 0; i < _slotPrefabs.Count; i++)
        {
            var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
            spawnedPiece.OnPiecePLaced += HandlePiecePlaced;
        }
    }

    private void HandlePiecePlaced()
    {
        _piecesPlaced++;
        if (_piecesPlaced >= _slotPrefabs.Count)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
