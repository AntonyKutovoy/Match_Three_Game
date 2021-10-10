using System.Windows.Forms;

namespace Match_3_game
{
    public abstract class Animation
    {
        protected Timer timer;
        protected GameForm game;
        protected int time = 250;
        protected int steps = 10;
        protected int count = 0;

        public delegate void AnimationEndHandler();

        public Animation(GameForm game)
        {
            this.game = game;
        }
    }
}
