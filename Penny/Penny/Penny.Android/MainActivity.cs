using Android.App;
using Android.Widget;
using Android.OS;

namespace Penny.Droid
{
    [Activity(Label = "Penny", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        Button btnLogin, btnSignup;
        EditText edtUsername, edtPassword;
   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Matching component-variables to views in the UI through their resource IDs in the resource.designer.cs file
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnSignup = FindViewById<Button>(Resource.Id.btnLoginSignup);

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtUsername = FindViewById<EditText>(Resource.Id.edtLoginUsername);

            //Adding action listeners to the buttons
            btnSignup.Click += BtnSignup_Click;
            btnLogin.Click += BtnLogin_Click;


        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            
        }

        private void BtnSignup_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}

