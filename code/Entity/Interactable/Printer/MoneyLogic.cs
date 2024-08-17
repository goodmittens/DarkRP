using Sandbox;
using GameSystems.Player;

namespace Entity.Interactable.Printer
{
    public sealed class MoneyLogic : Component, IInteractable
    {
        [Property]
        public int Money = 100;

        public void InteractUse( SceneTraceResult tr, GameObject player )
        {
            Log.Info( "Interacting with money" );
            var playerStats = player.Components.Get<Stats>();
            if ( playerStats != null )
            {
                playerStats.AddMoney( Money );
                Sound.Play( "audio/money.sound" );
                DestroyMoney();
            }
        }

        [Broadcast]
        public void DestroyMoney() { this.GameObject.Destroy(); } // If it doesn't work with private void use public void

    }
}