namespace Gof.Design.Patterns.Winforms.Patterns.Template
{
    public class ProcessTemplate
    {
        public ProcessTemplate() { }

        public void Run()
        {
            ProcessAbstract attendance = new Attendance();
            attendance.Run();

            ProcessAbstract deduction = new Deduction();
            deduction.Run();
        }
    }
}
