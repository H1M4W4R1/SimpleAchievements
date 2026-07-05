using JetBrains.Annotations;
using Systems.SimpleAchievements.Abstract.Platforms;
using Systems.SimpleCore.Storage.Databases;

namespace Systems.SimpleAchievements.Data.Databases
{
    /// <summary>
    ///     Lazy-loaded Addressable database of all <see cref="AchievementPlatformBase"/> assets in the project.
    ///     Assets are automatically registered via the <c>AutoCreate</c> attribute on
    ///     <see cref="AchievementPlatformBase"/> and must carry the <see cref="LABEL"/> Addressable label.
    /// </summary>
    public sealed class AchievementPlatformDatabase
        : AddressableDatabase<AchievementPlatformDatabase, AchievementPlatformBase>
    {
        /// <summary>Addressable label applied to all platform assets.</summary>
        public const string LABEL = "SimpleAchievements.Platforms";

        [NotNull] protected override string AddressableLabel => LABEL;
    }
}
