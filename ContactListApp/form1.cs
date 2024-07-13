using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ContactListApp
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts = new List<Contact>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                contacts.Add(new Contact { Name = textBoxName.Text, Phone = textBoxPhone.Text });
                UpdateContactList();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please enter both Name and Phone.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex >= 0)
            {
                Contact selectedContact = contacts[listBoxContacts.SelectedIndex];
                selectedContact.Name = textBoxName.Text;
                selectedContact.Phone = textBoxPhone.Text;
                UpdateContactList();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please select a contact to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex >= 0)
            {
                contacts.RemoveAt(listBoxContacts.SelectedIndex);
                UpdateContactList();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please select a contact to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex >= 0)
            {
                Contact selectedContact = contacts[listBoxContacts.SelectedIndex];
                textBoxName.Text = selectedContact.Name;
                textBoxPhone.Text = selectedContact.Phone;
            }
        }

        private void UpdateContactList()
        {
            listBoxContacts.Items.Clear();
            foreach (var contact in contacts)
            {
                listBoxContacts.Items.Add(contact);
            }
        }

        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxPhone.Clear();
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Phone}";
        }
    }
}
