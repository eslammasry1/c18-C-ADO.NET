using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsWinForms_PresentationLayer4
{
    public partial class frmAllContacts : Form
    {
        public frmAllContacts()
        {
            InitializeComponent();
        }
        private void _RefreshContactList()
        {
            dgvAllContact.DataSource = clsContact.GetAllCotact();
        }

        private void frmAllContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact((int)dgvAllContact.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshContactList();

        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContact.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsContact.DeleteContact((int)dgvAllContact.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }

        }

        private void btnAddNContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactList();

        }
    }
}
