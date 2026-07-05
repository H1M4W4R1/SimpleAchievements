using JetBrains.Annotations;
using Systems.SimpleAchievements.Abstract;
using Systems.SimpleCore.Storage.Databases;

namespace Systems.SimpleAchievements.Data.Databases
{
    /// <summary>
    ///     Lazy-loaded Addressable database of all <see cref="AchievementData"/> assets in the project.
    ///     Assets are automatically registered via the <c>AutoCreate</c> attribute on
    ///     <see cref="AchievementData"/> and must carry the <see cref="LABEL"/> Addressable label.
    /// </summary>
    public sealed class AchievementDatabase : AddressableDatabase<AchievementDatabase, AchievementData>
    {
        /// <summary>Addressable label applied to all achievement assets.</summary>
        public const string LABEL = "SimpleAchievements.Achievements";

        [NotNull] protected override string AddressableLabel => LABEL;
    }
}
