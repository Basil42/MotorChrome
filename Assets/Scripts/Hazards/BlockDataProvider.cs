using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace Hazards
{
    [RequireComponent(typeof(BlockDestroyer),typeof(BlockMover),typeof(BlockColorHandler))]
    public class BlockDataProvider : MonoBehaviour
    {
        [SerializeField] private BlockDestroyer blockDestroyer;
        [SerializeField] private BlockMover blockMover;
        [SerializeField] private BlockColorHandler blockColorHandler;

        [SerializeField] private int speedReward = 1;
        [SerializeField] private int speedPenalty = 2;

        public int SpeedReward => speedReward;
        
        public int SpeedPenalty;

        private void Awake()
        {
            Assert.IsNotNull(blockDestroyer);
            Assert.IsNotNull(blockMover);
            Assert.IsNotNull(blockColorHandler);
        }

        public BlockDestroyer GetBlockDestroyer()
        {
            return blockDestroyer;
        }

        public BlockMover GetBlockMover()
        {
            return blockMover;
        }

        public BlockColorHandler GetBlockColorHandler()
        {
            return blockColorHandler;
        }
    }
}
