using Gof.Design.Patterns.Winforms.Forms.Employee;
using Gof.Design.Patterns.Winforms.Patterns.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gof.Design.Patterns.Winforms.Forms
{
    public partial class FrmEmployee : Form
    {
        private int index = 0;
        public FrmEmployee()
        {
            InitializeComponent();
        }
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            this.ShowList();
        }

        private List<Entities.Employee> list = new List<Entities.Employee>();
        public void ShowList()
        {
            dgvList.DataSource = null;
            EmployeeFacade employeeFacade = new EmployeeFacade();
            BindingSource source = new BindingSource();
            this.list = employeeFacade.EmployeeList;
            source.DataSource = employeeFacade.EmployeeList;
            //dgvList.DataSource = source;
            dgvList.DataSource = employeeFacade.EmployeeList;
            dgvList.Refresh();
            dgvList.Update();

            foreach (DataGridViewColumn col in dgvList.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
                

        }
        private void RemoveRow()
        {
            DialogResult ans = MessageBox.Show("Are you sure you want to remvoe this row?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.No) return;

            int selected = this.index;
            EmployeeFacade employeeFacade = new EmployeeFacade();
            employeeFacade.RemoveEmployee(selected);
            this.ShowList();
        }
        private void button_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            switch (btn.Name)
            {
                case "mnuCreate":
                    FrmEmployeeEntry.Instance.EntryMode = Enums.EntryMode.Creating;
                    FrmEmployeeEntry.Instance.ShowDialog();
                    break;
                case "mnuEdit":
                    FrmEmployeeEntry.Instance.index = this.index;
                    FrmEmployeeEntry.Instance.EntryMode = Enums.EntryMode.Editing;
                    FrmEmployeeEntry.Instance.ShowDialog();
                    break;
                case "mnuDelete":
                    this.RemoveRow();
                    break;
                case "mnuRefresh":
                    this.ShowList();
                    break;
                case "mnuProcess":
                    FrmProcess.Instance.ShowDialog();
                    break;
                case "mnuCompute":
                    FrmComputation.Instance.ShowDialog();
                    break;
                default:
                    break;
            }
        }


        private void FrmEmployee_Resize(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            this.index = dgvList.CurrentCell.RowIndex;
        }


        private int _previousIndex;
        private bool _sortDirection;
        private void dgvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // toggle direction

            dgvList.DataSource = SortData(
                (List<Entities.Employee>)dgvList.DataSource, dgvList.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;
        }
        private List<Entities.Employee> SortData(List<Entities.Employee> list, string column, bool ascending)
        {
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }

    }
}

