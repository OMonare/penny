using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Penny.Models;
using Penny.Repositories;

namespace Penny.Droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText edtName, edtPhone, edtCity, edtEmail, edtUsername, edtPassword, edtConfirmPassword;
        Button btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            SetContentView(Resource.Layout.Register);

            base.OnCreate(savedInstanceState);

            //Matching component-variables to views in the UI through their resource IDs in the resource.designer.cs file
            edtName = FindViewById<EditText>(Resource.Id.edtRegisterName);
            edtCity = FindViewById<EditText>(Resource.Id.edtRegisterCiry);
            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtRegisterConfirmPassword);
            edtEmail = FindViewById<EditText>(Resource.Id.edtRegiterEmail);
            edtPhone = FindViewById<EditText>(Resource.Id.edtRegisterPhone);
            edtPassword = FindViewById<EditText>(Resource.Id.edtRegisterPassword);
            edtUsername = FindViewById<EditText>(Resource.Id.edtRegisterUsername);

            btnRegister = FindViewById<Button>(Resource.Id.btnRegisterRegister);

            btnRegister.Click += BtnRegister_Click;

        }

        private async void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                  user = await UserRepo.Register(edtName.Text, edtPhone.Text, edtCity.Text, edtPassword.Text, edtUsername.Text, edtEmail.Text);
                if (user != null){
                    Toast.MakeText(this, "Registration was successful", ToastLength.Long).Show();
                    var userString =JsonConvert.SerializeObject(user);
                    Intent intent = new Intent(this, typeof(AddItemActivity));
                    intent.PutExtra("user",userString);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Registration failed", ToastLength.Long).Show();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                Toast.MakeText(this, "Registration failed here", ToastLength.Long).Show();
            }
        }
    }
}