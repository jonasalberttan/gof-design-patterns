
namespace Gof.Design.Patterns.Winforms.Patterns.Template
{
    public abstract class ProcessAbstract
    {
        public abstract void Clean();
        public abstract void Compute();


        public void Run()
        {
            this.Clean();
            this.Compute();
        }
    }
}
