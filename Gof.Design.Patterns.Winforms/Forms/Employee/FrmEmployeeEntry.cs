using Gof.Design.Patterns.Winforms;
using Gof.Design.Patterns.Winforms.Entities;
using Gof.Design.Patterns.Winforms.Entities.Shared;
using Gof.Design.Patterns.Winforms.Extensions;
using Gof.Design.Patterns.Winforms.Patterns.Facade;
using Gof.Design.Patterns.Winforms.Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gof.Design.Patterns.Winforms.Forms.Employee
{
    public partial class FrmEmployeeEntry : Form
    {
        private enum ennColContacts : int
        {
            Name=1,
            Description             
        }
        private enum ennColAddresses : int
        {
            Name = 1,
            Description
        }

        private static int _index=0;
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        public FrmEmployeeEntry()
        {
            InitializeComponent();
        }

        private void ClearEntries()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtName.Text = "";
            dgvContacts.DataSource = null;
            dgvAddress.DataSource = null;
        }
        private void Fetch()
        {
            this.ClearEntries();
            EmployeeFacade employeeFacade = new EmployeeFacade();
            Entities.Employee employee = employeeFacade.EmployeeList[this.index];
            txtLastName.Text = employee.LastName;
            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName;
            txtName.Text = employee.Name;
                        
            if (employee.Contacts != null)
            {
                foreach (var contact in employee.Contacts)
                {
                    dgvContacts.Rows.Add("", contact.Name, contact.Description);
                }
            }
                        
            if (employee.Addresses != null)
            {
                foreach (var address in employee.Addresses)
                {
                    dgvAddress.Rows.Add("", address.Name, address.Description);
                }
            }

        }
        private void button_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            
            switch (btn.Name)
            {
                case "mnuSave":
                    if (this.EntryMode==Enums.EntryMode.Creating) this.Save();
                    else if (this.EntryMode == Enums.EntryMode.Editing) this.Update();
                    break;
                case "mnuEdit":
                    this.EntryMode = Enums.EntryMode.Editing;
                    break;
                case "mnuDelete":
                    break;
                case "mnuCancelEdit":
                    this.EntryMode = Enums.EntryMode.Viewing;
                    break;
                case "mnuClose":
                    this.Close();
                    break;
                default:
                    break;
            }
            this.HandleEnableButtons();
            this.HandleEnableEntries();
        }

        private bool HasRequiredFields()
        {
            bool required = txtLastName.Text.IsRequired() ||
                txtFirstName.Text.IsRequired() ||
                txtLastName.Text.IsRequired();

            if (txtLastName.Text.IsRequired()) this.AddStatus("Lastname is a required field.");
            if (txtFirstName.Text.IsRequired()) this.AddStatus("Firstname is a required field.");
            if (txtMiddleName.Text.IsRequired()) this.AddStatus("Middlename is a required field.");
                        
            foreach (DataGridViewRow row in dgvContacts.Rows)
            {
                if (row.Cells[(int)ennColContacts.Name].Value.IsRequired())
                {
                    required = true;
                    this.AddStatus("Name is require in row " + row.Index + " of contact list.");
                }
                else if (row.Cells[(int)ennColContacts.Description].Value.IsRequired())
                {
                    required = true;
                    this.AddStatus("Description is require in row " + row.Index + " of contact list.");
                }
            }

            foreach (DataGridViewRow row in dgvAddress.Rows)
            {
                if (row.Cells[(int)ennColContacts.Name].Value.IsRequired())
                {
                    required = true;
                    this.AddStatus("Name is require in row " + row.Index + " of address list.");
                }
                else if (row.Cells[(int)ennColContacts.Description].Value.IsRequired())
                {
                    required = true;
                    this.AddStatus("Description is require in row " + row.Index + " of address list.");
                }
            }

            if (required) MessageBox.Show("Please check the status below for the require field/s.", "Required...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return required;
        }

        public void Save()
        {
            if (this.HasRequiredFields()) return;

            EmployeeFacade employeeFacade = new EmployeeFacade();

            #region Save the header information.

            Entities.Employee employee = new Entities.Employee();
            employee.LastName = txtLastName.Text;
            employee.FirstName = txtFirstName.Text;
            employee.MiddleName = txtMiddleName.Text;
            employee.Name = txtLastName.Text + ", " + txtFirstName.Text + " " + txtMiddleName.Text;
            employee.Contacts = new List<Entities.Contact>();
            employee.Addresses = new List<Entities.Address>();
            employeeFacade.SaveEmployee(employee);
            this.AddStatus("Saving employee's header information...");

            #endregion

            #region Save the contact list.

            List<Entities.Contact> contactList = new List<Entities.Contact>();
            foreach (DataGridViewRow row in dgvContacts.Rows)
            {
                //long ContacTypesId = long.Parse((row.Cells[1] as DataGridViewComboBoxCell).Value.ToString());
                string Name = row.Cells[(int)ennColContacts.Name].Value.ToString();
                string Description = row.Cells[(int)ennColContacts.Description].Value.ToString();

                contactList.Add(new Entities.Contact()
                {
                    Name = Name,
                    Description = Description,
                    CreatedAt = DateTime.Now.StandardFormat(),
                    UpdatedAt = DateTime.Now.StandardFormat()
                });
                this.AddStatus("Adding contact - " + Name + ".");
            }
            employeeFacade.SaveContacts(employee, contactList);

            #endregion

            #region Save the address list.

            List<Entities.Address> addressList = new List<Entities.Address>();
            foreach (DataGridViewRow row in dgvAddress.Rows)
            {
                string Name = row.Cells[(int)ennColAddresses.Name].Value.ToString();
                string Description = row.Cells[(int)ennColAddresses.Description].Value.ToString();

                addressList.Add(new Entities.Address()
                {
                    Name = Name,
                    Description = Description,
                    CreatedAt = DateTime.Now.StandardFormat(),
                    UpdatedAt = DateTime.Now.StandardFormat()
                });
                this.AddStatus("Adding adress - " + Name + ".");
            }
            employeeFacade.SaveAddresses(employee, addressList);

            #endregion

            // Refresh the list.
            FrmEmployee.Instance.mnuRefresh.PerformClick();
            FrmEmployee.Instance.Refresh();
            this.Close();
        }
        public void Update()
        {
            if (this.HasRequiredFields()) return;

            EmployeeFacade employeeFacade = new EmployeeFacade();

            #region Save the header information.

            Entities.Employee employee = new Entities.Employee();
            employee.LastName = txtLastName.Text;
            employee.FirstName = txtFirstName.Text;
            employee.MiddleName = txtMiddleName.Text;
            employee.Name = txtLastName.Text + ", " + txtFirstName.Text + " " + txtMiddleName.Text;
            employee.Contacts = new List<Entities.Contact>();
            employee.Addresses = new List<Entities.Address>();
            employeeFacade.SaveEmployee(employee, this.index);
            this.AddStatus("Saving employee's header information...");

            #endregion

            #region Save the contact list.

            List<Entities.Contact> contactList = new List<Entities.Contact>();
            foreach (DataGridViewRow row in dgvContacts.Rows)
            {
                //long ContacTypesId = long.Parse((row.Cells[1] as DataGridViewComboBoxCell).Value.ToString());
                string Name = row.Cells[(int)ennColContacts.Name].Value.ToString();
                string Description = row.Cells[(int)ennColContacts.Description].Value.ToString();

                contactList.Add(new Entities.Contact()
                {
                    Name = Name,
                    Description = Description,
                    CreatedAt = DateTime.Now.StandardFormat(),
                    UpdatedAt = DateTime.Now.StandardFormat()
                });
                this.AddStatus("Adding contact - " + Name + ".");
            }
            employeeFacade.SaveContacts(employee, contactList);

            #endregion

            #region Save the address list.

            List<Entities.Address> addressList = new List<Entities.Address>();
            foreach (DataGridViewRow row in dgvAddress.Rows)
            {
                string Name = row.Cells[(int)ennColAddresses.Name].Value.ToString();
                string Description = row.Cells[(int)ennColAddresses.Description].Value.ToString();

                addressList.Add(new Entities.Address()
                {
                    Name = Name,
                    Description = Description,
                    CreatedAt = DateTime.Now.StandardFormat(),
                    UpdatedAt = DateTime.Now.StandardFormat()
                });
                this.AddStatus("Adding adress - " + Name + ".");
            }
            employeeFacade.SaveAddresses(employee, addressList);

            #endregion

            // Refresh the list.
            FrmEmployee.Instance.mnuRefresh.PerformClick();
            FrmEmployee.Instance.Refresh();
            this.Close();
        }

        private void FrmEmployeeEntry_Load(object sender, EventArgs e)
        {
            this.HandleEnableButtons();
            this.DataGridViewStatusInit();
            this.DataGridViewContactInit();
            this.DataGridViewAddressInit();            
            this.HandleDisplayEntries();
            this.AddStatus("The entry has been initialized.");
        }

        private void HandleEnableButtons()
        {
            switch (this.EntryMode)
            {
                case Enums.EntryMode.Viewing:
                    mnuCancelEdit.Enabled = false;
                    mnuDelete.Enabled = true;
                    mnuEdit.Enabled = true;
                    mnuSave.Enabled = false;
                    break;
                case Enums.EntryMode.Creating:
                    mnuCancelEdit.Enabled = false;
                    mnuDelete.Enabled = false;
                    mnuEdit.Enabled = false;
                    mnuSave.Enabled = true;
                    break;
                case Enums.EntryMode.Editing:
                    mnuCancelEdit.Enabled = true;
                    mnuDelete.Enabled = false;
                    mnuEdit.Enabled = false;
                    mnuSave.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void HandleEnableEntries()
        {
            switch (this.EntryMode)
            {
                case Enums.EntryMode.Viewing:
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtMiddleName.Enabled = false;
                    break;
                case Enums.EntryMode.Creating:
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtMiddleName.Enabled = true;
                    break;
                case Enums.EntryMode.Editing:
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtMiddleName.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void HandleDisplayEntries()
        {
            switch (this.EntryMode)
            {
                case Enums.EntryMode.Viewing:
                    this.Fetch();
                    break;
                case Enums.EntryMode.Creating:
                    this.ClearEntries();
                    break;
                case Enums.EntryMode.Editing:
                    this.Fetch();
                    break;
                default:
                    break;
            }
            this.HandleEnableEntries();
        }


        #region dgvStatus

        private void AddStatus(string msg)
        {
            dgvStatus.Rows.Insert(0, new string[]
            {
                DateTime.Now.StandardDt(), msg
            });
            dgvStatus.RowsDefaultCellStyle.BackColor = Color.Black;
            dgvStatus.RowsDefaultCellStyle.ForeColor = Color.White;

        }
        private DataTable dgvStatusDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(System.Windows.Forms.Button));
            dt.Columns.Add("Message", typeof(String));
            return dt;
        }
        private void DataGridViewStatusInit()
        {
            dgvStatus.AutoGenerateColumns = false;

            DataGridViewColumn colDate = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "statDate";
            colDate.HeaderText = "Date";
            colDate.Name = "statDate";
            colDate.Width = 100;
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewColumn colMessage = new DataGridViewTextBoxColumn();
            colDate.DataPropertyName = "statMessage";
            colMessage.HeaderText = "Message";
            colMessage.Name = "statMessage";
            colMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dgvStatus.Columns.Add(colDate);
            dgvStatus.Columns.Add(colMessage);

        }


        #endregion

        #region dgvContacts

        private void DataGridViewContactInit()
        {
            dgvContacts.AutoGenerateColumns = false;

            DataGridViewImageColumn dgv_btnRemove = new DataGridViewImageColumn();
            dgv_btnRemove.HeaderText = "";
            dgv_btnRemove.Name = "btnRemoveContact";
            dgv_btnRemove.Image = imageList1.Images[0];
            dgv_btnRemove.Width = 30;
            dgv_btnRemove.ToolTipText = "Remove this row...";

            //DataGridViewComboBoxColumn dgv_cboType = new DataGridViewComboBoxColumn();
            //dgv_cboType.DataSource = this.dtContactTypes();
            //dgv_cboType.HeaderText = "Type";
            //dgv_cboType.DisplayMember = "Name";
            //dgv_cboType.ValueMember = "Id";
            //dgv_cboType.Width = 100;

            DataGridViewTextBoxColumn dgv_txtName = new DataGridViewTextBoxColumn();
            dgv_txtName.HeaderText = "Value";
            dgv_txtName.DataPropertyName = "Name";
            dgv_txtName.Width = 100;

            DataGridViewTextBoxColumn dgv_txtDescription = new DataGridViewTextBoxColumn();
            dgv_txtDescription.HeaderText = "Description";
            dgv_txtDescription.DataPropertyName = "Description";
            dgv_txtName.Width = 100;

            dgvContacts.Columns.AddRange(dgv_btnRemove, dgv_txtName, dgv_txtDescription);
        }
        private DataTable dgvContactDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Action", typeof(System.Windows.Forms.Button));
            //dt.Columns.Add("Type", typeof(String));
            dt.Columns.Add("Value", typeof(String));
            dt.Columns.Add("Description", typeof(String));
            return dt;
        }
        private DataTable dtContactTypes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Rows.Add(new object[] { 1, "Mobile" });
            dt.Rows.Add(new object[] { 2, "Phone (home)" });
            dt.Rows.Add(new object[] { 3, "Email" });
            return dt;
        }
        private void btnAddContacts_Click(object sender, EventArgs e)
        {
            dgvContacts.Rows.Add();
        }
        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                dgvContacts.Rows.Remove(dgvContacts.Rows[e.RowIndex]);
            }
        }

        #endregion

        private void Saving()
        {
            using (SQLiteConnection con = Connection.Instance.Initialize)
            {

            }
        }

        #region dgvAddress

        private void DataGridViewAddressInit()
        {
            dgvAddress.AutoGenerateColumns = false;

            DataGridViewImageColumn dgv_add_btnRemove = new DataGridViewImageColumn();
            dgv_add_btnRemove.HeaderText = "";
            dgv_add_btnRemove.Name = "btnRemoveContact";
            dgv_add_btnRemove.Image = imageList1.Images[0];
            dgv_add_btnRemove.Width = 30;
            dgv_add_btnRemove.ToolTipText = "Remove this row...";

            //DataGridViewComboBoxColumn dgv_cboType = new DataGridViewComboBoxColumn();
            //dgv_cboType.DataSource = this.dtContactTypes();
            //dgv_cboType.HeaderText = "Type";
            //dgv_cboType.DisplayMember = "Name";
            //dgv_cboType.ValueMember = "Id";
            //dgv_cboType.Width = 100;

            DataGridViewTextBoxColumn dgv_add_txtName = new DataGridViewTextBoxColumn();
            dgv_add_txtName.HeaderText = "Value";
            dgv_add_txtName.DataPropertyName = "Name";
            dgv_add_txtName.Width = 100;

            DataGridViewTextBoxColumn dgv_add_txtDescription = new DataGridViewTextBoxColumn();
            dgv_add_txtDescription.HeaderText = "Description";
            dgv_add_txtDescription.DataPropertyName = "Description";
            dgv_add_txtDescription.Width = 100;

            dgvAddress.Columns.AddRange(dgv_add_btnRemove, dgv_add_txtName, dgv_add_txtDescription);
        }
        private DataTable dgvAddressDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Action", typeof(System.Windows.Forms.Button));
            //dt.Columns.Add("Type", typeof(String));
            dt.Columns.Add("Value", typeof(String));
            dt.Columns.Add("Description", typeof(String));
            return dt;
        }
        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            dgvAddress.Rows.Add();
        }
        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvAddress.Rows.Remove(dgvAddress.Rows[e.RowIndex]);
            }
        }

        #endregion



    }
}
