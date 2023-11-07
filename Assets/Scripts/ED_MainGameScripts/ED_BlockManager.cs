using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED_BlockManager : MonoBehaviour
{
    private float _spawnTicker = 0f;
    [SerializeField] public float baseEnemySpeed = 10f;
    [SerializeField] public float distanceToSpawn = 70f;

    private readonly int[][] _blockArray = new int[22][]; // Creating an array of arrays
    private int _currentBlockArray = 0;

    private GameObject _prefab;

    // Start is called before the first frame update
    void Awake()
    {
        // Initializing the inner arrays
        _blockArray[0] = new int[] { 10, 1 };
        _blockArray[1] = new int[] { 20, 2 };
        _blockArray[2] = new int[] { 10, 3 };
        _blockArray[3] = new int[] { 10, 4 };
        _blockArray[4] = new int[] { 10, 5 };
        _blockArray[5] = new int[] { 10, 6 };
        _blockArray[6] = new int[] { 10, 7 };
        _blockArray[7] = new int[] { 10, 8 };
        _blockArray[8] = new int[] { 20, 9 };
        _blockArray[9] = new int[] { 10, 10 };

        _blockArray[10] = new int[] { 10, 11 };
        _blockArray[11] = new int[] { 20, 12 };
        _blockArray[12] = new int[] { 10, 13 };
        _blockArray[13] = new int[] { 10, 14 };
        _blockArray[14] = new int[] { 10, 15 };
        _blockArray[15] = new int[] { 10, 16 };
        _blockArray[16] = new int[] { 10, 17 };
        _blockArray[17] = new int[] { 10, 18 };
        _blockArray[18] = new int[] { 20, 19 };
        _blockArray[19] = new int[] { 10, 20 };
        _blockArray[20] = new int[] { 10, 21 };
        _blockArray[21] = new int[] { 10, 22 };
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnBlock();
    }

    void spawnBlock()
    {
        int[] row = _blockArray[_currentBlockArray];
        
        _prefab = Resources.Load("Prefabs/p_" + row[1]) as GameObject;
        Instantiate(_prefab, new Vector3(0, 1.5f, distanceToSpawn), Quaternion.identity);

        _currentBlockArray++;
        if (_currentBlockArray >= _blockArray.Length) {
            _currentBlockArray = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTicker += Time.deltaTime;
        if (_spawnTicker * baseEnemySpeed >= _blockArray[_currentBlockArray][0]) {
            _spawnTicker = 0f;
            spawnBlock();
        }
    }
}
