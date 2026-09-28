using RimWorld;
using Verse;

namespace DustBunnies
{
    /// <summary>
    /// Replaces the static field the 1.1-1.3 code used to hold the pawn kind:
    ///
    ///   public static PawnKindDef Pawn_DustBunny = DefDatabase&lt;PawnKindDef&gt;.GetNamed("DustBunny");
    ///
    /// An inline static field initialiser runs the first time anything touches the class, at a
    /// moment the mod does not choose. In practice it worked, because RecipeDef.Worker is lazy and
    /// by the time a bill runs the def database is long since built, but a failure there surfaces as
    /// a TypeInitializationException with the real cause two levels down, and the field never
    /// rebinds if the database is reloaded. [DefOf] binds it once the database is complete, and
    /// again after any reload, through the game's own DefOfHelper.
    /// </summary>
    [DefOf]
    public static class DustBunniesDefOf
    {
        public static PawnKindDef DustBunny;

        static DustBunniesDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DustBunniesDefOf));
        }
    }
}
