namespace _Game._Scripts.Utilities
{
    public class State
    {
        private Cooldown cooldown = new Cooldown();
        public string name { get; }
        public int statID { get; }
        public int value { get; }

        public State(int statID, string name, int value, float time)
        {
            this.statID = statID;
            this.name = name;
            this.value = value;

            this.cooldown.setTime(time);
            this.cooldown.StartCooldown();
        }

        public bool timeEnd()
        {
            return !cooldown.isCoolingDown;
        }
    }
}