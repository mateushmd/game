using System.Reflection.Emit;

namespace _Game.Data
{
    public class DSkill
    {
        public string name { get; private set; }
        public int index { get; private set; }
        public DVector2 startingPosition { get; private set; }
        public ESightType sight { get; private set; }
        public DVector2 range { get; private set; }
        public float cooldownTime { get; }
        public Cooldown cooldown { get; }

        public DSkill(string n, int id, DVector2 sp, ESightType sig, DVector2 ran, float coolTime, Cooldown cool)
        {
            name = n;
            index = id;
            startingPosition = sp;
            sight = sig;
            range = ran;
            cooldownTime = coolTime;
            cooldown = cool;
        }
        
    }
}