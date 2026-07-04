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
using static System.Windows.Forms.AxHost;
using System;
using System.Windows.Forms;
using System.IO;

namespace ContactsWinForms_PresentationLayer4
{
    public partial class frmAddEditContact : Form
    {
        public enum enMode {AddMode = 0,UpdateMode = 1};
        private enMode _Mode ;
        private int _ContactID;
        private clsContact _Contact;
        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();
            _ContactID = ContactID;
            if (_ContactID == -1)
                _Mode = enMode.AddMode;
            else
                _Mode = enMode.UpdateMode;
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cBCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _LoadData()
        {
            _FillCountriesInComboBox();
            cBCountry.SelectedIndex = 0;
            if (_ContactID == -1)
            {
                lblOperation.Text = "Add New Contact";
                _Contact = new clsContact();
                return;
            }
            _Contact = clsContact.Find(_ContactID);
            if (_Contact == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _ContactID);
                this.Close();
                return;
            }
            lblOperation.Text = "Edit Contact ID = " + _ContactID;
            lblID.Text = _ContactID.ToString();
            txtbFName.Text = _Contact.FirstName;
            txtbLName.Text = _Contact.LastName;
            txtbEmail.Text = _Contact.Email;
            txtbPhone.Text = _Contact.Phone;
            txtBAddress.Text = _Contact.Address;
            dTPBirth.Value = _Contact.DateOfBirth;

            if (!string.IsNullOrEmpty(_Contact.ImagePath) && File.Exists(_Contact.ImagePath))
            {
                pictureBox1.Load(_Contact.ImagePath);
            }
            else
            {
                pictureBox1.Image = null;
            }
            //if (_Contact.ImagePath != "") 
            //{
            //    pictureBox1.Load(@"C:\Users\Mega Store\Downloads\Telegram Desktop\photo_2026-07-03_08-48-32.jpg");
            //}
            //else
            //{
            //    pictureBox1.Image = null;
            //}
            lLablRemove.Visible = (_Contact.ImagePath != "");

            cBCountry.SelectedIndex = cBCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CoountryID = clsCountry.Find(cBCountry.Text).ID;
            _Contact.FirstName = txtbFName.Text;
            _Contact.LastName = txtbLName.Text;
            _Contact.Email = txtbEmail.Text;
            _Contact.Phone = txtbPhone.Text;
            _Contact.Address = txtBAddress.Text; ;
            _Contact.DateOfBirth = dTPBirth.Value;
            _Contact.CountryID = CoountryID;

            if (pictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = pictureBox1.ImageLocation;
            }
            else
            {
                _Contact.ImagePath = "";
            }
            if (_Contact.Save())
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("ERORR : Data  IS NOT Saved Successfully");
            }
            _Mode = enMode.UpdateMode;
            lblOperation.Text = "Edit Contact ID = " + _Contact.ID;
            lblID.Text = _Contact.ID.ToString();
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lLablSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pictureBox1.Load(selectedFilePath);
                // ...
            }

        }

        private void lLablRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            lLablRemove.Visible = false;

        }
    }
}
