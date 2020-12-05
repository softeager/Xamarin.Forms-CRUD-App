using CRUDApp.Services;
using CRUDApp.Model;
using CRUDApp.Views;
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
    public partial class ShowStudents : ContentPage
    {
        StudentService services;
        public ShowStudents()
        {
            InitializeComponent();
            services = new StudentService();
        }

  

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showStudent();
        }
        private void showStudent()
        {
            var res = services.GetAllStudents().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddStudent());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                StudentModel obj = (StudentModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddStudent(obj));
                        break;
                    case "Delete":
                        services.DeleteStudent(obj);
                        showStudent();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}