using System;
using System.Collections;
using System.Collections.Generic;
using Hazards;
using Pickups;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBlockCollision : MonoBehaviour , IPickupConsumer<ShieldPickup>
{ //This Should be placed on the player -Gustav
    
    
    //This value could be used to increase speed based on consecutive block breaks -Gustav
    public int brokenBlocks;
    [SerializeField] const int BreakAmount = 2;

    //This number should be linked to Elio's color change script. -Gustav
    private int _playersColorNum, _fillRange; 

    private ColorState _blockColorState;

    private ColorState _playersColorState;
    private IColorGet _getPlayerColor;

    [SerializeField] private GameObject blockShatterEffect;
    [SerializeField] private GameObject slowShatterEffect;

    [Range(0, 1)] [SerializeField] private float speedNegativeModifier = 0.15f;
    
    public void Awake()
    {
        _getPlayerColor = GetComponent<IColorGet>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //_enemyRenderer = other.GetComponent<Renderer>();
        
        if (other.CompareTag("BreakableBlock"))
        {
            var blockData = other.GetComponent<BlockDataProvider>();
            _blockColorState = blockData.GetBlockColorHandler().GetColorState();

            _playersColorState = _getPlayerColor.GetColorState();
            
            
            if ((int)(_blockColorState & _playersColorState) != 0)
            {
                        BreakBlock(blockData);
            }
            else if (_isShielded)//to be fixed
            {
                _isShielded = false;
                    
            }
            else{
                GameObject blockShatterEffectClone = Instantiate(slowShatterEffect, blockData.transform.position, blockData.transform.rotation);
                blockShatterEffectClone.GetComponent<Renderer>().material = blockData.gameObject.GetComponentInChildren<Renderer>().material;//this is probably horrible performance wise. 
                Destroy(blockShatterEffectClone, 2f);

                blockData.SpeedPenalty = Mathf.Max(BreakAmount, (int)Mathf.Round(brokenBlocks*speedNegativeModifier)) ;
                
                brokenBlocks -= blockData.SpeedPenalty;
                OnMismatchedBlockHit?.Invoke(blockData);
            }          
            
            brokenBlocks = Mathf.Max(brokenBlocks, 1);
            //BreakableBlocksGeneration breakableBlock = other.GetComponent<BreakableBlocksGeneration>(); 
            //breakableBlock.GenerateBlock();
            
            blockData.GetBlockDestroyer().DestroyBlock();
            
            /*
            
                 if (_playerRenderer.sharedMaterial.color == _enemyRenderer.material.color)
                 {
                     print(_enemyRenderer.material.color.ToString());
                     BreakBlock();
                     changeColorBarUp.Invoke();
                     //StartCoroutine(ChangeColorBar(FillBarAmount));
                 }
                 else
                 {
                     brokenBlocks -= BreakAmount;
                     changeColorBarDown.Invoke();
                 }    */
        }
    }

    public event Action<BlockDataProvider> OnBlockDestroyed;
    public event Action<BlockDataProvider> OnMismatchedBlockHit;
    private void BreakBlock(BlockDataProvider block)
    {
        GameObject blockShatterEffectClone = Instantiate(blockShatterEffect, block.transform.position, block.transform.rotation);
        blockShatterEffectClone.GetComponent<Renderer>().material = block.gameObject.GetComponentInChildren<Renderer>().material;//this is probably horrible performance wise. 
        Destroy(blockShatterEffectClone, 2f);
        OnBlockDestroyed?.Invoke(block);
        if (block.TryGetComponent(out IPickup pu))
        {
            pu.Apply(gameObject);
        }
        
        brokenBlocks++;
    }

    private bool _isShielded = false;
    public void ApplyPickup(ShieldPickup pickup)
    {
        _isShielded = true;
    }
}
