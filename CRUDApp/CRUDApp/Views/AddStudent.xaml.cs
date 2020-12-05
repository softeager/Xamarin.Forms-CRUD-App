using CRUDApp.Model;
using CRUDApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudent : ContentPage
    {
        StudentService _services;
        bool _isUpdate;
        int studentID;

        public AddStudent()
        {
            InitializeComponent();
            _services = new StudentService();
            _isUpdate = false;

        }

        public AddStudent(StudentModel obj)
        {
            InitializeComponent();
            _services = new StudentService();
            if (obj != null)
            {
                studentID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtContact.Text = obj.Contact_No;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            StudentModel obj = new StudentModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Contact_No = txtContact.Text;
            if (_isUpdate)
            {
                obj.Id = studentID;
                await _services.UpdateStudent(obj);
            }
            else
            {
                _services.InsertStudent(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}