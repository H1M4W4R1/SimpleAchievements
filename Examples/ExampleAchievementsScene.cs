using Systems.SimpleAchievements.Abstract;
using Systems.SimpleAchievements.Examples.Achievements;
using Systems.SimpleAchievements.Structs;
using Systems.SimpleAchievements.Utility;
using Systems.SimpleCore.Operations;
using UnityEngine;

namespace Systems.SimpleAchievements.Examples
{
    [DisallowMultipleComponent]
    public sealed class ExampleAchievementsScene : MonoBehaviour
    {
        [SerializeField] private AchievementData _manualAchievement;
        [SerializeField] private ExampleConditionalAchievement _conditionalAchievement;
        [SerializeField] private int _conditionIncrements = 3;

        private void Start()
        {
            RunExample();
        }

        [ContextMenu("Run Achievements Example")]
        public void RunExample()
        {
            UnlockManualAchievement();
            UnlockConditionalAchievement();
        }

        private void UnlockManualAchievement()
        {
            if (ReferenceEquals(_manualAchievement, null) || !_manualAchievement)
            {
                Debug.LogWarning("[SimpleAchievements] Manual achievement asset is not assigned.");
                return;
            }

            AchievementUnlockContext context = new AchievementUnlockContext(_manualAchievement);
            OperationResult result = AchievementAPI.Unlock(in context);
            Debug.Log("[SimpleAchievements] Manual unlock result: " + result);
        }

        private void UnlockConditionalAchievement()
        {
            if (ReferenceEquals(_conditionalAchievement, null) || !_conditionalAchievement)
            {
                Debug.LogWarning("[SimpleAchievements] Conditional achievement asset is not assigned.");
                return;
            }

            ExampleConditionalAchievement.ResetCount();

            AchievementUnlockContext blockedContext = new AchievementUnlockContext(_conditionalAchievement);
            OperationResult blockedResult = AchievementAPI.Unlock(in blockedContext);
            Debug.Log("[SimpleAchievements] Conditional unlock before progress: " + blockedResult);

            for (int incrementIndex = 0; incrementIndex < _conditionIncrements; incrementIndex++)
            {
                ExampleConditionalAchievement.IncrementCount();
            }

            AchievementUnlockContext readyContext = new AchievementUnlockContext(_conditionalAchievement);
            OperationResult readyResult = AchievementAPI.Unlock(in readyContext);
            Debug.Log("[SimpleAchievements] Conditional unlock after progress: " + readyResult);
        }
    }
}
