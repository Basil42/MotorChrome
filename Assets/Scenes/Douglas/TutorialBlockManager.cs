using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBlockManager : MonoBehaviour
{
    private float _spawnTicker = 0f;
    [SerializeField] public float baseEnemySpeed = 10f;
    [SerializeField] public float distanceToSpawn = 70f;

    private readonly int[][] _blockArray = new int[50][]; // Creating an array of arrays
    private int _currentBlockArray = 0;

    private GameObject _prefab;

    // Start is called before the first frame update
    void Awake()
    {
        // Initializing the inner arrays
        _blockArray[0] = new int[] { 10, 23 };
        _blockArray[1] = new int[] { 50, 9 };
        _blockArray[2] = new int[] { 50, 4 };
        _blockArray[3] = new int[] { 50, 24 };
        _blockArray[4] = new int[] { 40, 25 };
        _blockArray[5] = new int[] { 35, 26 };
        _blockArray[6] = new int[] { 30, 27 };
        _blockArray[7] = new int[] { 20, 28 };
        _blockArray[8] = new int[] { 30, 29 };
        _blockArray[9] = new int[] { 20, 30 };

        _blockArray[10] = new int[] { 20, 32 };
        _blockArray[11] = new int[] { 20, 31 };
        _blockArray[12] = new int[] { 15, 34 };
        _blockArray[13] = new int[] { 15, 35 };
        _blockArray[14] = new int[] { 15, 33 };
        _blockArray[15] = new int[] { 1, 36 };
        _blockArray[16] = new int[] { 1, 36 };
        _blockArray[17] = new int[] { 1, 36 };
        _blockArray[18] = new int[] { 120, 19 };
        _blockArray[19] = new int[] { 110, 20 };
        _blockArray[20] = new int[] { 110, 21 };
        _blockArray[21] = new int[] { 110, 22 };
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnBlock();
    }

    void spawnBlock()
    {
        int[] row = _blockArray[_currentBlockArray];
        Debug.Log(row[1]);
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
