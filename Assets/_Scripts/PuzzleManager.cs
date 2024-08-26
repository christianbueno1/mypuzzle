using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;

    [SerializeField] private Transform _slotParent, _pieceParent;

    private int _piecesPlaced = 0;

    void Start()
    {
        Spawn();
    }
    
    void Spawn()
    {
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
            StartCoroutine(ShowMessageAndLoadNextLevel());
            
        }
    }

    private IEnumerator ShowMessageAndLoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
    
        if (nextSceneIndex == 5)
        {
            nextSceneIndex = 0; // Load the scene with index 0 if the next level is index 5
        }
    
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
    }
}
