
namespace Gof.Design.Patterns.Winforms.Patterns.Proxy
{
    class ComputationProxy : IComputation
    {
        private Computation _computation = new Computation();
        public void Deductions()
        {
            _computation.Deductions();
        }

        public void GrossIncome()
        {
            _computation.GrossIncome();
        }

        public void NetIncome()
        {
            _computation.NetIncome();
        }
    }
}
